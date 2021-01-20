<template>
    <div>
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
        <p>{{selectedItem}}</p>
        <div class="m-3 text-center">
            <button class="btn btn-primary">Добавить</button>
            <button class="btn btn-primary">Редактировать</button>
            <button class="btn btn-primary" type="button" v-on:click="removeItemTable">Удалить</button>
        </div>
        <p v-for="item in myrows">{{item}}</p>
    </div>
</template>

<script>
    // import the styles
    import 'vue-good-table/dist/vue-good-table.css'
    import { VueGoodTable } from 'vue-good-table';

    export default {
        name: "table-component",
        data: function () {
            return {
                selectedItem: null
            }
        },
        methods: {
            removeItemTable: function () {
                //alert('remove item')
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
            
        },
        props: ['myrows', 'mycolumns'],
        components: {
            VueGoodTable
        },
    }
</script>