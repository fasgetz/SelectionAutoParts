<template>
    <div v-if="data != null">
        <h3 class="text-center">
            <span v-if="editdata == null">Добавление поля категории</span>
            <span v-else>Редактирование поля категории</span>
        </h3>
        <div class="form-group row p-1">
            <label class="col-sm-2 col-form-label">Название</label>
            <div class="col-sm-10">
                <input minlength="5" v-model="data.name" type="text" class="form-control" placeholder="Введите название поля">
            </div>
        </div>
        <div class="form-group row p-1">
            <label class="col-sm-2 col-form-label">Тип</label>
            <div class="col-sm-10">
                <select v-on:change="ChangeInputType(data.inputType)" required v-model="data.inputType" class="form-control">
                    <option value="text">Текстовый</option>
                    <option value="number">Числовой</option>
                </select>
            </div>
        </div>
        <fieldset class="form-group">
            <div class="row">
                <legend class="col-form-label col-sm-2 pt-0">Обязательное заполнение</legend>
                <div class="col-sm-10">
                    <div class="form-check">
                        <input class="form-check-input" type="radio" v-model="data.required" value="true" checked>
                        <label class="form-check-label" for="gridRadios1">
                            Да
                        </label>
                    </div>
                    <div class="form-check">
                        <input class="form-check-input" type="radio" v-model="data.required" value="false">
                        <label class="form-check-label" for="gridRadios2">
                            Нет
                        </label>
                    </div>
                </div>
            </div>
        </fieldset>
        <div v-if="data.inputType == 'number'">
            <div class="form-group row p-1">
                <label class="col-sm-2 col-form-label">Минимум</label>
                <div class="col-sm-10">
                    <input step="0.01" v-model="data.min" type="number" class="form-control" placeholder="Введите минимальное число">
                </div>
            </div>
            <div class="form-group row p-1">
                <label class="col-sm-2 col-form-label">Максимум</label>
                <div class="col-sm-10">
                    <input step="0.01" v-model="data.max" type="number" class="form-control" placeholder="Введите максимальное число">
                </div>
            </div>
        </div>
        <div v-if="data.inputType == 'text'">
            <div class="form-group row p-1">
                <label class="col-sm-2 col-form-label">Минимум</label>
                <div class="col-sm-10">
                    <input step="1" v-model="data.minLength" type="number" class="form-control" placeholder="Введите минимальное количество символов">
                </div>
            </div>
            <div class="form-group row p-1">
                <label class="col-sm-2 col-form-label">Максимум</label>
                <div class="col-sm-10">
                    <input step="1" v-model="data.maxLength" type="number" class="form-control" placeholder="Введите максимальное количество символов">
                </div>
            </div>
        </div>
        <div class="pt-3 text-center">
            <button v-if="editdata == null" v-on:click="addItem" class="btn btn-success">Добавить</button>
            <button v-else v-on:click.prevent="saveEditItem" class="btn btn-success">Сохранить</button>
            <button v-on:click="cancel" class="btn btn-primary">Отменить</button>
        </div>
    </div>
</template>

<script>
    export default {
        name: "addform-component",
        data: function () {
            return {
                data: {
                    name: null,
                    inputType: null,
                    required: false,
                    min: null,
                    max: null,
                    minLength: null,
                    maxLength: null
                }
            };
        },
        methods: {
            saveEditItem: function () {

                this.$emit('save', this.data)


            },
            cancel: function () {
                this.$emit('cancel')
            },
            addItem: function () {

                this.$emit('add', this.data)
            },
            ChangeInputType: function (item) {
                if (item == "text") {
                    this.data.min = null
                    this.data.max = null
                }

                if (item == "number") {
                    this.data.minLength = null
                    this.data.maxLength = null
                }
            }
        },
        mounted() {
            //alert('admin ss')
            if (this.editdata != null)
                this.data = this.editdata
            //this.data = editData
        },
        props: ['editdata']
    }
</script>