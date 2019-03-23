import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import Home from "./components/Home.vue"
import User from "./components/user/User.vue"
import userDetails from "./components/user/User.Details.vue"

Vue.use(VueRouter)
Vue.use(Vuetify)

const routes = [
    { path: '/', component: Home },
    { path: '/user', component: User },
    { path: '/user/create', component: userDetails, name: "userDetails", props: true },
    { path: '*', redirect: '/' }
]

const router = new VueRouter({
    routes
})
  
const app = new Vue({
    el: '#app',
    render: h => h(App),
    router: router,
})