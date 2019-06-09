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
              <h1>Engenharia de Computação</h1>
            </div>
            <br>
            <br>
            <br>

            <!-- Tabela -->
            <table cellspacing="0" style="width:80%; margin-left: 10%;">
              <tr>
                <td>Disciplina Desenvolvimento de Aplicações para WEB</td>
                <td colspan="3" style="text-align: center;">Carga Horária</td> 
              </tr>
              <tr>
                <td>Professor Responsável André Breda Carneiro</td>
                <td style="text-align: center;">Teoria</td> 
                <td style="text-align: center;">Prática</td> 
                <td style="text-align: center;">Total</td> 
              </tr>
              <tr>
                <td>Coordenador Andréa Lucia Braga Vieira Rodrigues</td>
                <td style="text-align: center;">40</td> 
                <td style="text-align: center;">40</td> 
                <td style="text-align: center;">80</td> 
              </tr>
              <tr>
                <td>Atualização 05/03/2019</td>
                <td colspan="3"> 
                   <v-menu
                      v-model="menu2"
                      :close-on-content-click="false"
                      :nudge-right="40"
                      lazy
                      transition="scale-transition"
                      offset-y
                      full-width
                      min-width="290px"
                    >
                      <template v-slot:activator="{ on }">
                        <v-text-field
                          v-model="model.DateValidacaoNDE"
                          label="Picker without buttons"
                          prepend-icon="event"
                          readonly
                          v-on="on"
                        ></v-text-field>
                      </template>
                      <v-date-picker v-model="model.DateValidacaoNDE" @input="menu2 = false"></v-date-picker>
                    </v-menu>
              </td>
              </tr>
            </table>

            <div style="text-align: left; width: 80%; margin-left: 10%;">
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
              <br>
              <!-- objetivos -->

              <br>
              <h3>Competências</h3>
              <br>
              <!-- competencias -->

              <br>
              <h3>Habilidades</h3>
              <br>
              <!-- habilidades -->

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
              <br>

              <br>
              <h3>Bibliografia Complementar</h3>
              <br>

              <br>
              <h3>Membros do NDE</h3>
              <div v-for="item in model.nde">
                <v-checkbox :label="item.Name" hide-details></v-checkbox>
              </div>
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
        id: Number
    },
    data: function() {
        return {
          title: "Plano de Ensino",
          gobackUrl: "/subjectCurriculum",
          snackbar: false,
          snackbarCurrentMessage: '',
          snackbarMessages: ["Selecione um professor responsável pelo plano de ensino", "Já existe uma disciplina com esse código"],
          model: {
            id: 0,
            Ementa: '',
            ProgramContentM1: '',
            ProgramContentM2: '',
            TeachingMethod: '',
            Avaliacao: '',
            DateValidacaoNDE: new Date(),
            nde: [
              { Id: 1, Name: 'Alisson'},
              { Id: 2, Name: 'Gabriel'}
            ]
          },
          menu2: false
        }
    },
    created() {
      var vm = this;
      
      if(parseInt(vm.id) > 0)
      {
        vm.getItem(vm.id);
      }
    },
    methods: {
      create: function() {
        var isValid = this.$refs.form.validate();
       
        if(!isValid) return;

        var vm = this;

        api.post({ 
          data: vm.model,
          success: (data) => { 
            vm.$router.push('/subjectCurriculum/create/' + data.id)
          }
        });
      },
      edit: function() {
        var isValid = this.$refs.form.validate();

        if(!isValid) return;
      },
      getItem: function(id) {
        var vm = this;
        api.get({ path_params: [id], success: (data) => { vm.model = data; } });
      },
      goback: function() {
        this.$router.push(this.gobackUrl);
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