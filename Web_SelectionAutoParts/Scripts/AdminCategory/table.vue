<template>
    <div>
        <form v-on:submit="SaveCategory">
            <h2>Редактирование категории EDIT CATEGORY</h2>
            <div class="form-group">
                <label>Категория</label>
                <input v-model="mycategory.name" type="text" class="form-control" placeholder="Название категории">
            </div>
            <h3 class="text-center">Свойства</h3>
            <vue-good-table :columns="mycolumns"
                            :rows="myrows"
                            @on-row-click="onRowClick"
                            :search-options="{
                        enabled: true
                      }"
                            :pagination-options="{
    enabled: true,
    nextLabel: 'next',
    prevLabel: 'prev',
    rowsPerPageLabel: 'Строк на странице',
    ofLabel: 'of',
    pageLabel: 'page', // for 'pages' mode
    allLabel: 'All',
  }">
                <div slot="selected-row-actions">
                    <button class="btn btn-primary">Action 1</button>
                </div>
            </vue-good-table>
            <div class="m-3 text-center">
                <button type="button" v-on:click.prevent="addItem" class="btn btn-primary">Добавить</button>
                <button type="button" v-on:click.prevent="editItemFunc" class="btn btn-primary">Редактировать</button>
                <button class="btn btn-primary" type="button" v-on:click="removeItemTable">Удалить</button>
            </div>
            <div class="m-3 text-center">
                <button type="submit" class="btn btn-success">Сохранить</button>
                <button type="button" v-on:click="cancelUpdate" class="btn btn-secondary">Отменить</button>
            </div>
            <div v-if="addedItem == true">
                <addform-component v-on:add="addItemRow" v-on:cancel="addedItem = false"></addform-component>
            </div>
            <div v-if="editItem == true && selectedItem != null">
                <addform-component v-on:save="editableItem" v-bind:editdata="selectedItem" v-on:cancel="editItem = false"></addform-component>
            </div>
        </form>
    </div>
</template>

<script>
    // import the styles
    import 'vue-good-table/dist/vue-good-table.css'
    import { VueGoodTable } from 'vue-good-table';
    import addformComponent from './addForm.vue'

    export default {
        name: "table-component",
        data: function () {
            return {
                rows: null,
                selectedItem: null,
                addedItem: false,
                editItem: false,
                category: {
                    id: null,
                    name: null,
                    parentCategoryId: null
                },
            }
        },
        methods: {
            cancelUpdate: function () {
                this.$emit('canceled')
            },
            editableItem: function (item) {
                //alert('asd')
                // Прозвести замену
                let obj = {
                    name: item.name,
                    inputType: item.inputType,
                    required: item.required,
                    min: item.min,
                    max: item.max,
                    minLength: item.minLength,
                    maxLength: item.maxLength
                }


                this.myrows[item.originalIndex] = obj
                console.log(obj)
                this.editItem = false


            },
            editItemFunc: function () {
                this.addedItem = false
                this.editItem = true
            },
            SaveCategory: function () {
                event.preventDefault();

                var obj = {
                    name: this.mycategory.name,
                    id: this.mycategory.id,
                    ParentCategoryId: this.mycategory.parentCategoryId,
                    properties: JSON.stringify(this.myrows)
                }


                axios.put((urlApp + 'category/EditCategory'), obj)
                    .then(response => {

                        //$("#editCategoryForm").html(response.data)
                        // если updated == true, то свернуть блок редактирования. Иначе вывести ERROR
                        // В СЛУЧАЕ УСПЕШНОГО ЭДИТИНГА НАДО ОБНОВИТЬ ДЕРЕВО КАТЕГОРИЙ !!!

                        if (response.status == 200) {
                            
                            //this.rows = null
                            //this.myrows = null
                            this.$emit('updated')

                        }
                    });


            },
            addItemRow: function (item) {

                $(".clickable").removeClass("clickItem")
                this.addedItem = false

                this.myrows.push(item)

            },
            addItem: function () {
                

                this.addedItem = true
                this.editItem = false


                //this.$emit('add')

            },
            removeItemTable: function () {

                if (this.selectedItem != null) {
                    this.myrows.splice(this.selectedItem.originalIndex, 1)
                    this.selectedItem = null
                }
                    

            },
            onRowClick(params) {
                //alert(params.row.name)
                //console.log(params)
                //console.log(params.pageIndex)

                $(".clickable").removeClass("clickItem")
                $(".clickable").eq(params.pageIndex).addClass("clickItem")

                this.selectedItem = params.row
                this.$emit('selected', params.row)
            }
        },
        mounted() {
            console.log("first send data: ", this.myrows)


            

        },
        props: ['myrows', 'mycolumns', 'mycategory'],
        components: {
            VueGoodTable,
            addformComponent
        },
    }
</script>