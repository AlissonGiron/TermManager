<template>
  <div>
      <v-toolbar color="white" flat>
          <v-btn icon light>
            <v-icon @click="goback">arrow_back</v-icon>
          </v-btn>
      </v-toolbar>

        <v-container style='background-color: white;' grid-list-sm class="pa-4">
          <div class="xs6">
          <v-form ref="form" v-model="valid">
            <v-layout id="fields" row wrap>
              <div style="text-align: center; width: 100%;">
                <h2>Plano de Ensino</h2>
              </div>
              <br>
              <div style="text-align: center; width: 100%;">
                <h1>{{CourseName}}</h1>
              </div>
              <br>
              <br>
              <br>

              <!-- Tabela -->
              <table cellspacing="0" style="width:80%; margin-left: 10%;">
                <tr>
                  <td>Disciplina: {{SubjectName}}</td>
                  <td colspan="3" style="text-align: center;">Carga Horária</td> 
                </tr>
                <tr>
                  <td>Professor Responsável: {{ProfessorName}}</td>
                  <td style="text-align: center;">Teoria</td> 
                  <td style="text-align: center;">Prática</td> 
                  <td style="text-align: center;">Total</td> 
                </tr>
                <tr>
                  <td>e-mail: {{ProfessorEmail}}</td>
                  <td style="text-align: center;">{{model.TheoryWorkload}}</td> 
                  <td style="text-align: center;">{{model.PracticalWorkload}}</td> 
                  <td style="text-align: center;">{{model.TotalWorkload}}</td> 
                </tr>
              </table>

              <div style="text-align: left; width: 80%; margin-left: 10%;">
                <br>
                <br>
                <h3>Ementa</h3>
                <v-flex xs12>
                    <v-textarea
                      v-model="model.Ementa"
                      auto-grow
                      color="deep-purple"
                      rows="1"
                      :validate-on-blur='true'
                      :rules="[() => !!model.Ementa || 'Esse campo é obrigatório']"
                    ></v-textarea>
                </v-flex>

                <br>
                <h3>Objetivos</h3>
                <div v-if="model.Goals.length > 0">
                  <div v-for="item in model.Goals">
                    <v-checkbox v-model="item.Checked" :label="item.Goal.Description" hide-details></v-checkbox>
                  </div>
                </div>
                <div v-else>
                  Nenhum item disponível
                </div>
                <!-- objetivos -->

                <br>
                <br>
                <h3>Competências</h3>
                <div v-if="model.Competences.length > 0">
                  <div v-for="item in model.Competences">
                    <v-checkbox  v-model="item.Checked" :label="item.Competence.Description" hide-details></v-checkbox>
                  </div>
                </div>
                <div v-else>
                  Nenhum item disponível
                </div>

                <!-- competencias -->

                <br>
                <br>
                <h3>Habilidades</h3>
                <div v-if="model.Skills.length > 0">
                  <div v-for="item in model.Skills">
                    <v-checkbox v-model="item.Checked" :label="item.Skill.Description" hide-details></v-checkbox>
                  </div>
                </div>
                <div v-else>
                  Nenhum item disponível
                </div>

                <!-- habilidades -->

                <br>
                <br>
                <h3>Conteúdo Programático</h3>
                <br>
                <h4 style="margin-left: 5%;">Módulo 1</h4>
                <v-flex xs12 style="margin-left: 5%;">
                    <v-textarea
                      v-model="model.ProgramContentM1"
                      auto-grow
                      color="deep-purple"
                      rows="1"
                      :validate-on-blur='true'
                      :rules="[() => !!model.ProgramContentM1 || 'Esse campo é obrigatório']"
                    ></v-textarea>
                </v-flex>

                <h4 style="margin-left: 5%;">Módulo 2</h4>
                <v-flex xs12 style="margin-left: 5%;">
                    <v-textarea
                      v-model="model.ProgramContentM2"
                      auto-grow
                      color="deep-purple"
                      rows="1"
                      :validate-on-blur='true'
                      :rules="[() => !!model.ProgramContentM2 || 'Esse campo é obrigatório']"
                    ></v-textarea>
                </v-flex>

                <br>
                <h3>Metodologia de ensino</h3>
                <v-flex xs12>
                    <v-textarea
                      v-model="model.TeachingMethod"
                      auto-grow
                      color="deep-purple"
                      rows="1"
                      :validate-on-blur='true'
                      :rules="[() => !!model.TeachingMethod || 'Esse campo é obrigatório']"
                    ></v-textarea>
                </v-flex>

                <br>
                <h3>Avaliação</h3>
                <v-flex xs12>
                    <v-textarea
                      v-model="model.Avaliacao"
                      auto-grow
                      color="deep-purple"
                      rows="1"
                      :validate-on-blur='true'
                      :rules="[() => !!model.Avaliacao || 'Esse campo é obrigatório']"
                    ></v-textarea>
                </v-flex>

                <br>
                <h3>Bibliografia Básica</h3>
                <div v-if="model.BBibliography.length > 0">
                  <div v-for="item in model.BBibliography">
                    <v-checkbox v-model="item.Checked" :label="item.Book.Description" hide-details></v-checkbox>
                  </div>
                </div>
                <div v-else>
                  Nenhum item disponível
                </div>

                <br>
                <br>
                <h3>Bibliografia Complementar</h3>
                <div v-if="model.CBibliography.length > 0">
                  <div v-for="item in model.CBibliography">
                    <v-checkbox v-model="item.Checked" :label="item.Book.Description" hide-details></v-checkbox>
                  </div>
                </div>
                <div v-else>
                  Nenhum item disponível
                </div>

                <br>
                <br>
                <h3>Membros do NDE</h3>
                <div v-if="model.NDEMembers.length > 0">
                  <div v-for="item in model.NDEMembers">
                    <v-checkbox v-model="item.Checked" :label="item.NDEMember.Description" hide-details></v-checkbox>
                  </div>
                </div>
                <div v-else>
                  Nenhum item disponível
                </div>
                <br>
                <br>
              </div>
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
  import {SubjectCurriculum} from "../../scripts/api_subjectCurriculum"
  var api = new SubjectCurriculum();

  export default {
    name: 'subjectCurriculumDetails',
    props: {
        idCourse: Number,
        IdSubject: Number
    },
    data: function() {
        return {
          IdSubject: 1,
          IdCourse: 1,
          title: "Plano de Ensino",
          gobackUrl: "/subjectCurriculum",
          snackbar: false,
          snackbarCurrentMessage: '',
          showPlan: false,
          CourseName: '',
          SubjectName: '',
          ProfessorName: '',
          ProfessorEmail: '',
          snackbarMessages: ["Selecione um professor responsável pelo plano de ensino", "Já existe uma disciplina com esse código"],
          model: {
            id: 0,
            IdSubject: 1,
            IdCourse: 1,
            IdProfessor: 0,
            Ementa: '',
            ProgramContentM1: '',
            TheoryWorkload: 0,
            PracticalWorkload: 0,
            TotalWorkload: 0,
            ProgramContentM2: '',
            TeachingMethod: '',
            Avaliacao: '',
            Goals: [],
            Competences: [],
            Skills: [],
            NDEMembers: [],
            BBibliography: [],
            CBibliography: [],
            Bibliography: []
          },
          menu2: false
        }
    },
    created() {
      var vm = this;

      vm.model.IdCourse = vm.IdCourse;
      vm.model.IdSubject = vm.IdSubject;

      vm.getDetails();

      vm.model.Ementa = "a";
      vm.model.Avaliacao = "aval";
      vm.model.ProgramContentM1 = "m1";
      vm.model.ProgramContentM2 = "m2";
      vm.model.TeachingMethod = "ensino";
    },
    methods: {
      create: function() {
        var isValid = this.$refs.form.validate();

        if(!isValid) return;

        var vm = this;
        
        vm.model.Skills = vm.model.Skills.filter((e) => e.Checked);
        vm.model.Goals = vm.model.Goals.filter((e) => e.Checked);
        vm.model.Competences = vm.model.Competences.filter((e) => e.Checked);
        vm.model.BBibliography = vm.model.BBibliography.filter((e) => e.Checked);
        vm.model.CBibliography = vm.model.CBibliography.filter((e) => e.Checked);
        vm.model.NDEMembers = vm.model.NDEMembers.filter((e) => e.Checked);
       
        vm.model.Bibliography = vm.model.BBibliography.concat(vm.model.CBibliography);
        
        api.post({ 
          data: vm.model,
          success: (data) => { 
            vm.goback();
          }
        });
      },
      goback: function() {
        this.$router.push(this.gobackUrl);
      },
      getDetails: function() {
        var vm = this;
        api.getCollections(vm.IdCourse, vm.IdSubject, (data) => { 
            data.NDEMembers.forEach((e) => e["Checked"] = true)
            data.Goals.forEach((e) => e["Checked"] = true)
            data.Competences.forEach((e) => e["Checked"] = true)
            data.Skills.forEach((e) => e["Checked"] = true)
            data.BBooks.forEach((e) => e["Checked"] = true)
            data.CBooks.forEach((e) => e["Checked"] = true)

            vm.model.Goals = data.Goals;
            vm.model.Competences = data.Competences;
            vm.model.Skills = data.Skills;
            vm.model.NDEMembers = data.NDEMembers;
            vm.model.BBibliography = data.BBooks;
            vm.model.CBibliography = data.CBooks;
            vm.CourseName = data.CourseName;
            vm.model.TheoryWorkload = data.TheoryWorkload;
            vm.model.PracticalWorkload = data.PracticalWorkload;
            vm.model.TotalWorkload = data.TotalWorkload;
            vm.SubjectName = data.SubjectName;
            vm.ProfessorName = data.ProfessorName;
            vm.ProfessorEmail = data.ProfessorEmail;
            vm.model.IdProfessor = data.IdProfessor;
        });
      }
    }
  }
</script>


<style scoped>
  table, td {
     border: 1px solid grey;
     border-collapse: collapse;
     padding: 10px;
     margin: 0;
  }
</style>