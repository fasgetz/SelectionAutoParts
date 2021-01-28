<template>
    <div>
        <form class="form">
            <div class="form-group">
                <label>Название категории</label>
                <input class="form-control" type="text" v-model="data.name" />
            </div>
            <div class="text-center">
                <input class="btn btn-success" v-on:click="addCategory" type="button" value="Создать" />
                <input class="btn btn-primary" v-on:click="cancel" type="button" value="Отменить" />
            </div>
        </form>
    </div>
</template>

<script>
    export default {
        name: "addcategory-component",
        props: ['id'],
        data: function () {
            return {
                data: {
                    ParentCategoryId: null, // Айди категории-родителя
                    name: null
                }
            };
        },
        methods: {
            addCategory: function () {
                


                // Логика запроса
                axios.post((urlApp + 'category/AddCategory'), this.data)
                    .then(response => {

                        //$("#editCategoryForm").html(response.data)
                        // если updated == true, то свернуть блок редактирования. Иначе вывести ERROR
                        // В СЛУЧАЕ УСПЕШНОГО ЭДИТИНГА НАДО ОБНОВИТЬ ДЕРЕВО КАТЕГОРИЙ !!!

                        // если успешно удалось добавить
                        if (response.status == 200) {
                            this.$emit("added");
                        }


                    });

                
                
            },
            cancel: function () {
                this.$emit("cancel");
            }                        
        },
        mounted() {
            //this.data.idParentCategory = idParent
            this.data.ParentCategoryId = this.id            
        }        
    }
</script>