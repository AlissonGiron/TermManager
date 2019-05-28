<template>
  <div>
    <v-toolbar color="white" flat>
        <v-btn icon light>
          <v-icon @click="goback">arrow_back</v-icon>
        </v-btn>

        <v-toolbar-title class="grey--text text--darken-4">{{ title }}</v-toolbar-title>
    </v-toolbar>

      <v-container style='background-color: white;' grid-list-sm class="pa-4">
        <div class="xs6">
        <v-form ref="form" v-model="valid">

          <v-layout id="fields" row wrap>
            <v-flex xs6>
              <v-text-field v-model="model.Code" label="Código" :validate-on-blur='true' :rules="[(v) => !!v || 'Esse campo é obrigatório']"></v-text-field>
            </v-flex>
            <v-flex xs6>
              <v-text-field v-model="model.Period" label="Período" :validate-on-blur='true' :rules="[(v) => !!v || 'Esse campo é obrigatório']"></v-text-field>
            </v-flex>

            <v-flex xs6>
              <v-select 
                v-model="model.SemesterNumber"
                :items="semesters"
                label="Selecione um semestre do ano"
              ></v-select>
            </v-flex>
            <v-flex xs6>
              <v-text-field type="number" v-model="model.Year" label="Ano" :validate-on-blur='true' :rules="[(v) => v >= 0 || 'Esse campo não pode ser negativo']"></v-text-field>
            </v-flex>
            
            <v-flex xs6>
              <p>Curso</p>
              <v-select 
                v-model="model.IdCourse"
                item-value="id"
                item-text="name" 
                :items="courses"
                label="Curso"
                solo
                @change="readSubjects"
              ></v-select>
            </v-flex>

            <v-flex xs6>
              <p>Disciplina</p>
              <v-select 
                v-model="model.IdSubject"
                item-value="id"
                item-text="name" 
                :items="subjects"
                label="Disciplina"
                solo
              ></v-select>
            </v-flex>

            <v-flex xs12>
              <p>Professor</p>
              <v-select 
                v-model="model.IdProfessor"
                item-value="id"
                item-text="name" 
                :items="professors"
                label="Professor"
                solo
              ></v-select>
            </v-flex>

          </v-layout>
        </v-form>
          <v-btn v-if="parseInt(this.id) > 0" color="warning" @click="edit">Salvar</v-btn>
          <v-btn v-else color="success" @click="create">Salvar</v-btn>
        </div>
      </v-container>

      <v-snackbar v-model="snackbar"
        :multi-line="true"
        color="red"
        :timeout="5000"
      >
        {{snackbarCurrentMessage}}
        <v-btn dark flat @click="snackbar = false">
          Ok
        </v-btn>
      </v-snackbar>
  </div>
</template>

<script>
  import {Class} from "../../scripts/api_class"
  var api = new Class();

  export default {
    name: 'classDetails',
    props: {
        id: String
    },
    data: function() {
        return {
          title: "Turma",
          gobackUrl: "/class",
          snackbar: false,
          snackbarCurrentMessage: '',
          snackbarMessages: ["Selecione um professor responsável pela turma", "Já existe uma turma com esse código"],
          model: {
            id: 0,
            Code: '',
            Period: '',
            IdProfessor: 0,
            IdCourse: 0,
            IdSubject: 0,
            SemesterNumber: 1,
            Year: 0,
          },
          professors: [],
          subjects: [],
          courses: [],
          semesters: [1, 2]
        }
    },
    created() {
      var vm = this;
      
      if(parseInt(vm.id) > 0)
      {
        vm.getItem(vm.id);
      }
      
      this.readProfessors();
      this.readCourses();
    },
    methods: {
      create: function() {
        var isValid = this.$refs.form.validate();

        if(this.model.IdProfessor == 0)
        {
          this.snackbarCurrentMessage = this.snackbarMessages[0];
          this.snackbar = true;
          isValid = false;
        }
        
        if(!isValid) return;

        var vm = this;

        api.checkCodeExists(0, this.model.Code, function(status) {
          if(status)
          {
             vm.snackbarCurrentMessage = vm.snackbarMessages[1];
             vm.snackbar = true;
             return;
          }
          
          api.post({ 
            data: vm.model,
            success: () => { 
              alert("Item salvo com sucesso");
              vm.$router.push(vm.gobackUrl);
            }
          });
        })
      },
      edit: function() {
        var isValid = this.$refs.form.validate();

        if(this.model.IdProfessor == 0)
        {
          this.snackbarCurrentMessage = this.snackbarMessages[0];
          this.snackbar = true;
          isValid = false;
        }
        
        if(!isValid) return;

        var vm = this;

        api.checkCodeExists(this.model.Id, this.model.Code, function(status) {
          if(status)
          {
             vm.snackbarCurrentMessage = vm.snackbarMessages[1];
             vm.snackbar = true;
             return;
          }
          
          api.put({
            data: vm.model, 
            path_params: [vm.model.Id],
            success: () => { 
              alert("Item editado com sucesso");
              vm.$router.push(vm.gobackUrl);
            }
          }); 
        })
      },
      readProfessors: function() {
        var vm = this;

        api.readProfessors(vm.model.IdProfessor, function(data) {
          vm.professors = data.map(function(e) { return { id: e.Id, name: e.UserName } });
        });
      },
      readCourses: function() {
        var vm = this;

        api.readCourses(vm.model.IdCourse, function(data) {
          vm.courses = data.map(function(e) { return { id: e.Id, name: e.Name } });

          vm.readSubjects();
        });
      },
      readSubjects: function() {
        var vm = this;
      
        api.readSubjects(0, vm.model.IdCourse, function(data) {
          vm.subjects = data.map(function(e) { return { id: e.Id, name: e.Name } });
        });
      },
      getItem: function(id) {
        var vm = this;
        api.get({ path_params: [id], success: (data) => vm.model = data });
      },
      goback: function() {
        this.$router.push(this.gobackUrl);
      }
    }
  }
</script>