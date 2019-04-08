<template>
  <div>
    <v-toolbar color="white" style="background-color: red;">
      <v-btn icon light>
        <v-icon color="grey darken-2">arrow_back</v-icon>
      </v-btn>

      <v-toolbar-title class="grey--text text--darken-4">Disciplinas</v-toolbar-title>
    </v-toolbar>
    <v-btn color="success" @click="$router.push('/subject/create/0')"><v-icon>add</v-icon> Novo</v-btn>
  <v-data-table
    :headers="headers"
    :items="subjects"
    class="elevation-1"
    :hide-headers="isMobile" :class="{mobile: isMobile}">
    <template v-slot:items="subjects">
      <tr v-if="!isMobile">
          <td>{{ subjects.item.Code }}</td>
          <td>{{ subjects.item.Name }}</td>
          <td>{{ subjects.item.TheoryWorkload }}</td>
          <td>{{ subjects.item.PracticalWorkload }}</td>
          <td>
            <v-btn color="warning" @click="$router.push('/subject/create/' + subjects.item.Id)"><v-icon>edit</v-icon></v-btn>
          </td>
          <td>
            <v-btn color="error" @click="deleteItem(subjects.item)"><v-icon>delete</v-icon></v-btn>
          </td>
      </tr>
      <tr v-else>
        <td>
          <v-layout row wrap>
            <v-flex xs6 data-label="Código">
              {{ subjects.item.Code }}
            </v-flex>
            <v-flex xs6 data-label="Nome">
              {{ subjects.item.Name }}
            </v-flex>
            <v-flex xs6 data-label="Carga Horária (Teoria)">
              {{ subjects.item.TheoryWorkload }}
            </v-flex>
            <v-flex xs6 data-label="Carga Horária (Prática)">
              {{ subjects.item.PracticalWorkload }}
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

  </div>
</template>

<script>

import {Subject} from "../../scripts/api_subject"
var api = new Subject();

export default {
    name: 'subject',
    data() {
        return {
            isMobile: false,
            headers: [
                { text: 'Código', value: 'Code' },
                { text: 'Nome', value: 'Name' },
                { text: 'Carga Horária (Teoria)', value: 'TheoryWorkload' },
                { text: 'Carga Horária (Prática)', value: 'PracticalWorkload' },
                { text: '', value: '' },
                { text: '', value: '' },
            ],
            title: 'Disciplinas',
            subjects: [],
            errorMessage: '',
            snackbar: false,
        };
    },
    beforeMount() {
        this.getSubjects()
    },
    methods: {
        getSubjects: function() {
          var vm = this;
          api.get({ success: function(e) { vm.subjects = e; }});
        },
        deleteItem: function(item) {
          if(confirm("Deseja realmente excluir esse item?"))
          {
            var vm = this;
            api.delete({ path_params: [item.Id], 
              success: (s) => vm.getSubjects(),
              error: function(s, i) {
                vm.errorMessage = s;
                vm.snackbar = true;
              }
            });
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
