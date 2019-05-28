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

import Subject from "./components/subject/Subject.vue"
import subjectDetails from "./components/subject/Subject.Details.vue"

import Class from "./components/class/Class.vue"
import classDetails from "./components/class/Class.Details.vue"

import Login from "./components/Login.vue"

Vue.component('layout', Layout)
Vue.component('login', Login)
Vue.use(VueRouter)
Vue.use(Vuetify)

const routes = [
    { path: '/', component: Home },
    { path: '/user', component: User },
    { path: '/user/create/:id', component: userDetails, name: "userDetails", props: true },
    { path: '/course', component: Course },
    { path: '/course/create/:id', component: courseDetails, name: "courseDetails", props: true },
    { path: '/term', component: Term },
    { path: '/term/create/:id', component: termDetails, name: "termDetails", props: true },
    { path: '/subject', component: Subject },
    { path: '/subject/create/:id', component: subjectDetails, name: "subjectDetails", props: true },
    { path: '/class', component: Class },
    { path: '/class/create/:id', component: classDetails, name: "classDetails", props: true },
    { path: '/logout', component: Login },
    { path: '*', redirect: '/' }
]

const router = new VueRouter({
    routes
})
  
const app = new Vue({
    data: {
        isLoggedIn: true,
        jwt_token: "",
        userName: ""
    },
    el: '#app',
    render: h => h(App),
    router: router
})