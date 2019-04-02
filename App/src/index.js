import Vue from 'vue';
import App from './App.vue';
import VueRouter from 'vue-router'
import Vuetify from 'vuetify'
import 'vuetify/dist/vuetify.min.css'
import Layout from "./components/Layout.vue"
import Home from "./components/Home.vue"

import User from "./components/user/User.vue"
import userDetails from "./components/user/User.Details.vue"

import Course from "./components/course/Course.vue"
import courseDetails from "./components/course/Course.Details.vue"

import Term from "./components/term/Term.vue"
import termDetails from "./components/term/Term.Details.vue"

import Login from "./components/Login.vue"

Vue.component('layout', Layout)
Vue.component('login', Login)
Vue.use(VueRouter)
Vue.use(Vuetify)

const routes = [
    { path: '/', component: Home },
    // { path: '/login', component: Login },
    { path: '/user', component: User },
    { path: '/user/create', component: userDetails, name: "userDetails", props: true },
    { path: '/course', component: Course },
    { path: '/course/create/:id', component: courseDetails, name: "courseDetails", props: true },
    { path: '/term', component: Term },
    { path: '/term/create/:id', component: termDetails, name: "termDetails", props: true },
    { path: '*', redirect: '/' }
]

const router = new VueRouter({
    routes
})
  
const app = new Vue({
    el: '#app',
    render: h => h(App),
    router: router
})