import Vue from 'vue'
import homeComponent from './home.vue'
import testingComponent from './homescript.vue'




new Vue({
    el: "#application",
    data: {
        message: "testing"
    },
    components: {
        homeComponent,
        testingComponent
    }
})