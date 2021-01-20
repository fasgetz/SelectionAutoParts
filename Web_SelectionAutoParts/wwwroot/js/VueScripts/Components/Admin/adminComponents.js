Vue.component('button-counter', {
    data: function () {
        return {
            count: 0
        }
    },
    template: '<button v-on:click="count++">Счётчик кликов — {{ count }}</button>'
})

Vue.component('message-comp', {
    props: ['message'],
    template: '<h2>{{ message }}</h2>'
})


Vue.component('vue-table', {
    props: ['data'],
    template: `
    <div>
        <div v-for="item in data" >
            {{item.name}}
            <div></div>
        </div>
    </div>`

})