<template>
  <div>
    <v-toolbar color="white" style="background-color: red;">
      <v-btn icon light>
        <v-icon color="grey darken-2">arrow_back</v-icon>
      </v-btn>

      <v-toolbar-title class="grey--text text--darken-4">Semestres</v-toolbar-title>
    </v-toolbar>
    <v-btn color="success" @click="$router.push('/term/create/0')"><v-icon>add</v-icon> Novo</v-btn>
  <v-data-table
    :headers="headers"
    :items="terms"
    class="elevation-1"
    :hide-headers="isMobile" :class="{mobile: isMobile}">
    <template v-slot:items="terms">
      <tr v-if="!isMobile">
          <td>{{ terms.item.SemesterNumber }}</td>
          <td>{{ terms.item.Year }}</td>
          <td>
            <v-btn color="warning" @click="$router.push('/term/create/' + terms.item.Id)"><v-icon>edit</v-icon></v-btn>
          </td>
          <td>
            <v-btn color="error" @click="deleteItem(terms.item)"><v-icon>delete</v-icon></v-btn>
          </td>
      </tr>
      <tr v-else>
        <td>
          <v-layout row wrap>
            <v-flex xs6 data-label="Código">
              {{ terms.item.SemesterNumber }}
            </v-flex>
            <v-flex xs6 data-label="Nome">
              {{ terms.item.Year }}
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

import {Term} from "../../scripts/api_term"
var api = new Term();

export default {
    name: 'term',
    data() {
        return {
            isMobile: false,
            headers: [
                { text: 'Número do Semestre', value: 'SemesterNumber' },
                { text: 'Ano', value: 'Year' },
                { text: '', value: '' },
                { text: '', value: '' },
            ],
            title: 'Semestres',
            terms: [],
            errorMessage: '',
            snackbar: false,
        };
    },
    beforeMount() {
        this.getTerms()
    },
    methods: {
        getTerms: function() {
          var vm = this;
          api.get({ success: function(e) { vm.terms = e; }});
        },
        deleteItem: function(item) {
          if(confirm("Deseja realmente excluir esse item?"))
          {
            var vm = this;
            api.delete({ path_params: [item.Id], success: () => vm.getTerms(), 
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
