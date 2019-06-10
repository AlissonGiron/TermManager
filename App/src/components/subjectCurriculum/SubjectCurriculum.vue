<template>
  <div>
    <v-toolbar color="white" style="background-color: red;">
      <v-btn icon light>
        <v-icon color="grey darken-2">arrow_back</v-icon>
      </v-btn>

      <v-toolbar-title class="grey--text text--darken-4">Planos de Ensino</v-toolbar-title>
    </v-toolbar>
    <v-btn color="success" @click="dialog = true"><v-icon>add</v-icon> Novo</v-btn>
  <v-data-table
    :headers="headers"
    :items="subjectCurriculums"
    class="elevation-1"
    :hide-headers="isMobile" :class="{mobile: isMobile}">
    <template v-slot:items="subjectCurriculums">
      <tr v-if="!isMobile">
            <td>
              {{ subjectCurriculums.item.Id }}
            </td>
          <td>
            <v-btn color="warning" @click="$router.push('/subjectCurriculum/pdf/' + subjectCurriculums.item.Id)"><v-icon>remove_red_eye</v-icon></v-btn>
          </td>
      </tr>
      <tr v-else>
        <td>
          <v-layout row wrap>
            <v-flex xs6 data-label="Código">
              {{ subjectCurriculums.item.Id }}
            </v-flex>
          </v-layout>
        </td>
      </tr>
    </template>
  </v-data-table>

     <v-snackbar v-model="snackbar"
        :multi-line="true"
        color="red"
        :timeout="5000"
      >
      {{errorMessage}}
      <v-btn dark flat @click="snackbar = false">
        Ok
      </v-btn>
    </v-snackbar>



    <v-dialog
      v-model="dialog"
      max-width="500"
    >
      <v-card>
        <v-card-title class="headline">Selecione o curso e a disciplina</v-card-title>

        <v-card-text>
          <br>
          <p>Curso</p>
          <v-select 
            v-model="IdCourse"
            item-value="id"
            item-text="name" 
            :items="courses"
            label="Curso"
            solo
          ></v-select>

          <br>
          <p>Disciplina</p>
          <v-select 
            v-model="IdSubject"
            item-value="id"
            item-text="name" 
            :items="subjects"
            label="Disciplina"
            solo
          ></v-select>
        </v-card-text>

        <v-card-actions>
          <v-spacer></v-spacer>
          <v-btn color="success" @click="goToCreate()"><v-icon>add</v-icon> Continuar</v-btn>
        </v-card-actions>
      </v-card>
    </v-dialog>


  </div>
</template>

<script>

import {SubjectCurriculum} from "../../scripts/api_subjectCurriculum"
var api = new SubjectCurriculum();

export default {
    name: 'subjectCurriculum',
    data() {
        return {
            isMobile: false,
            IdCourse: 0,
            IdSubject: 0,
            dialog: false,
            headers: [
                { text: 'Id', value: '' },
                { text: '', value: '' },
            ],
            title: 'Planos de Ensino',
            subjectCurriculums: [],
            errorMessage: '',
            snackbar: false,
            courses: [],
            subjects: [],
        };
    },
    beforeMount() {
        this.getsubjectCurriculums()
    },
    created() {
        var vm = this;

        api.readCourses(0, function(data) {
          vm.courses = data.map(function(e) { return { id: e.Id, name: e.Name } });
        });

        api.readSubjects(0, function(data) {
          vm.subjects = data.map(function(e) { return { id: e.Id, name: e.Name } });
        });
    },
    methods: {
        getsubjectCurriculums: function() {
          var vm = this;
          api.get({ success: function(e) { vm.subjectCurriculums = e; }});
        },
        goToCreate() {
          if(this.IdCourse == 0 || this.IdSubject == 0)
          {
            return;
          }

          this.$router.push('/subjectCurriculum/create/'+ this.IdCourse +'/'+ this.IdSubject);
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
