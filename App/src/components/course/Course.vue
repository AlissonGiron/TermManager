<template>
  <div>
    <v-toolbar color="white" style="background-color: red;">
      <v-btn icon light>
        <v-icon color="grey darken-2">arrow_back</v-icon>
      </v-btn>

      <v-toolbar-title class="grey--text text--darken-4">Cursos</v-toolbar-title>
    </v-toolbar>
    <v-btn color="success" @click="$router.push('/course/create/0')"><v-icon>add</v-icon> Novo</v-btn>
  <v-data-table
    :headers="headers"
    :items="courses"
    class="elevation-1"
    :hide-headers="isMobile" :class="{mobile: isMobile}">
    <template v-slot:items="courses">
      <tr v-if="!isMobile">
          <td>{{ courses.item.Code }}</td>
          <td>{{ courses.item.Name }}</td>
          <td>
            <v-btn color="warning" @click="$router.push('/course/create/' + courses.item.Id)"><v-icon>edit</v-icon></v-btn>
          </td>
          <td>
            <v-btn color="error" @click="deleteItem(courses.item)"><v-icon>delete</v-icon></v-btn>
          </td>
      </tr>
      <tr v-else>
        <td>
          <v-layout row wrap>
            <v-flex xs6 data-label="Código">
              {{ courses.item.Code }}
            </v-flex>
            <v-flex xs6 data-label="Nome">
              {{ users.item.Name }}
            </v-flex>
          </v-layout>
        </td>
      </tr>
    </template>
  </v-data-table>
  </div>

</template>

<script>

import {Course} from "../../scripts/api_course"
var apiCourse = new Course();

export default {
    name: 'course',
    data() {
        return {
            isMobile: false,
            headers: [
                { text: 'Código', value: 'Code' },
                { text: 'Nome', value: 'Name' },
                { text: 'Editar', value: 'Edit' },
                { text: 'Excluir', value: 'Delete' },
            ],
            title: 'Cursos',
            courses: []
        };
    },
    beforeMount() {
        this.getCourses()
    },
    methods: {
        getCourses: function() {
          var vm = this;
          apiCourse.get({ success: function(e) { vm.courses = e; }});
        },
        deleteItem: function(item) {
          if(confirm("Deseja realmente excluir esse item?"))
          {
            var vm = this;
            apiCourse.delete({ path_params: [item.Id], success: () => vm.getCourses() });
          } 
        }
    }
};
</script>

<style scoped>
  .mobile {
      color: #333;
    }

    @media screen and (max-width: 768px) {
      .mobile .flex.xs6:before {
        content: attr(data-label);
        padding-right: .5em;
        text-align: left;
        display: block;
        color: #999;
      }
    }
</style>
