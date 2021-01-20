<template>
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
</template>

<script>
    // import the styles
    import 'vue-good-table/dist/vue-good-table.css'
    import { VueGoodTable } from 'vue-good-table';

    export default {
        name: "table-component",
        methods: {
            onRowClick(params) {
                //alert(params.row.name)
                //console.log(params)
                //console.log(params.pageIndex)

                $(".clickable").removeClass("clickItem")
                $(".clickable").eq(params.pageIndex).addClass("clickItem")


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