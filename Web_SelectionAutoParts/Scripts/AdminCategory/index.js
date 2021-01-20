import Vue from 'vue'
import axios from 'axios'
import addformComponent from './addForm.vue'
import tableComponent from './table.vue'
import tree from './tree.vue'



new Vue({
    el: "#editCategory",
    mounted() {


        axios.get((urlApp + 'category/all'))
            .then(response => {
                this.treeData = response.data
            });

    },
    data: function () {
        return {
            treeData: null,
            category: {
                id: null,
                name: null,
                parentCategoryId: null
            },
            selectedItem: null,
            addedItem: false,
            editItem: false,
            rows: [],
            columns: [
                {
                    label: 'Название',
                    field: 'name',
                },
                {
                    label: 'Тип',
                    field: 'inputType',
                },
                {
                    label: 'Обязательное',
                    field: 'required',
                    type: 'boolean',
                },
                {
                    label: 'Минимальное число',
                    field: 'min',
                    type: 'number',
                },
                {
                    label: 'Максимальное число',
                    field: 'max',
                    type: 'number',
                },
                {
                    label: 'Минимум символов',
                    field: 'minLength',
                    type: 'number',
                },
                {
                    label: 'Максимум символов',
                    field: 'maxLength',
                    type: 'number',
                },
            ],
        };
    },
    methods: {
        makeFolder: function (item) {
            // Здесь создается подкатегория
            //alert(item.id)
            Vue.set(item, "childrenCategories", []);
            this.addItem(item);
        },
        addItem: function (item) {
            alert('abc')
            // Здесь создается итем в подкатегории
            item.childrenCategories.push({
                name: "new stuff"
            });
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


            this.rows[item.originalIndex] = obj
            console.log(obj)
            this.editItem = false


        },
        cancelEdit: function () {
            this.category = {
                id: null,
                name: null,
                parentCategoryId: null
            }

            $("#editCategoryForm").html(null)

        },
        SaveCategory: function () {
            event.preventDefault();

            var obj = {
                name: this.category.name,
                id: this.category.id,
                ParentCategoryId: this.category.parentCategoryId,
                properties: JSON.stringify(this.rows)
            }


            axios.put((urlApp + 'category/EditCategory'), obj)
                .then(response => {

                    $("#editCategoryForm").html(response.data)
                    // если updated == true, то свернуть блок редактирования. Иначе вывести ERROR
                    // В СЛУЧАЕ УСПЕШНОГО ЭДИТИНГА НАДО ОБНОВИТЬ ДЕРЕВО КАТЕГОРИЙ !!!

                    if (response.status == 200) {
                        alert('true updated')
                        this.category = {
                            id: null,
                            name: null,
                            parentCategoryId: null
                        }
                    }
                });


        },




        editItemForm: function (itemId) {


            axios.get((urlApp + 'category/get'), {
                params: {
                    id: itemId
                }
            })
                .then(response => {
                    console.log(response.data)

                    this.category = response.data.category

                    if (response.data.properties == null)
                        this.rows = new Array()
                    else
                        this.rows = response.data.properties
                });
        },
        itemSelect(item) {
            this.selectedItem = item
        },
        addItemForm: function () {
            $(".clickable").removeClass("clickItem")
            this.selectedItem = null
            this.addedItem = true
            this.editItem = false
        },
        addItemRow: function (item) {
            $(".clickable").removeClass("clickItem")
            this.addedItem = false

            this.rows.push(item)

            alert(this.rows.count)
        },
        removeItem: function () {
            if (this.selectedItem != null) {
                $(".clickable").removeClass("clickItem")
                this.rows.splice(this.selectedItem.originalIndex, 1)

                this.selectedItem = null
            }


        }
    },
    components: {
        axios,
        addformComponent,
        tableComponent,
        tree
    }
})