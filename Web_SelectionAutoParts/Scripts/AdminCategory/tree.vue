<template>
    <li>
        <div class="container">
            <div class="row align-items-center">
                <div class="col-md col-12">
                    <div :class="{bold: isFolder}"
                         
                         v-on:click="toggle">
                        {{ item.name }}
                        <span v-if="isFolder">[{{ isOpen ? '-' : '+' }}]</span>
                    </div>
                </div>
                <div class="col-md-4">
                    <button class="btn btn-primary p-1 m-1" v-on:click="editItem"><i class="far fa-edit"></i></button>
                    <button class="btn btn-primary p-1 m-1" v-on:click="addSubCategory"><i class="fas fa-folder-plus"></i></button>
                </div>
            </div>
            <ul v-show="isOpen" v-if="isFolder">
                <tree class="item"
                      v-for="(child, index) in item.childrenCategories"
                      :key="index"
                      v-on:edit="editItemForm"
                      v-on:addcategory="addItemForm"
                      v-on:addsubcategory="addSubCategoryTree"
                      v-bind:item="child"
                      v-bind:make-folder="$emit('make-folder', $event)"
                      v-bind:add-item="$emit('add-item', $event)"></tree>
                <li class="btn btn-primary add p-1 m-1" v-on:click="addItem">Добавить</li>

            </ul>
        </div>
    </li>
</template>

<script>

    export default {
        name: "tree",
        props: {
            item: Object
        },
        data: function () {
            return {
                isOpen: false
            };
        },
        computed: {
            isFolder: function () {
                return this.item.childrenCategories && this.item.childrenCategories.length;
            }
        },
        mounted() {

        },
        methods: {
            // Добавление подкатегории по клику на иконку с папкой со знаком +
            addSubCategoryTree: function (item) {
                
                this.$emit("addsubcategory", item);
            },
            addSubCategory: function () {
                if (this.item.childrenCategories == null)
                    this.$emit("addsubcategory", this.item.id);
                else
                    alert('Невозможно добавить подкатегорию, т.к. подкатегория уже добавлена!')
                
            },

            addItemForm: function (item) {
                this.$emit("addcategory", item);
            },
            addItem: function () {
                // Логика добавления итема

                this.$emit("addcategory", this.item.id);

                //this.item.childrenCategories.push({
                //    name: "new stuff"
                //});
            },
            editItemForm: function (item) {
                this.$emit("edit", item);
            },
            editItem: function () {
                // Функционал редактирования (перейти на страницу редактирования)

                this.$emit("edit", this.item.id);

            },
            removeItem: function () {
                // Функционал удаления (удалить)
                //alert(this.item.id)
            },
            toggle: function () {
                if (this.isFolder) {
                    this.isOpen = !this.isOpen;
                }
            },
            makeFolder: function () {
                if (!this.isFolder) {
                    this.$emit("make-folder", this.item);
                    this.isOpen = true;
                }
            }
        }
    }
</script>