import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import Layout from "./components/Layout.vue"
import Home from "./components/Home.vue"
import User from "./components/user/User.vue"
import userCreate from "./components/user/User.Create.vue"
import Login from "./components/Login.vue"

Vue.use(Layout)
Vue.use(VueRouter)
Vue.use(Vuetify)
//Vue.use(Login)

const routes = [
    { path: '/', component: Home },
    { path: '/login', component: Login },
    { path: '/user', component: User },
    { path: '/user/create', component: userCreate },
    { path: '*', redirect: '/' }
]

const router = new VueRouter({
    routes
})
  
const app = new Vue({
    el: '#app',
    render: h => h(App),
    router: router,
    components: {
        Login: Login
    }
})