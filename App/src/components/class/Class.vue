<template>
  <div>
    <v-toolbar color="white" style="background-color: red;">
      <v-btn icon light>
        <v-icon color="grey darken-2">arrow_back</v-icon>
      </v-btn>

      <v-toolbar-title class="grey--text text--darken-4">Turmas</v-toolbar-title>
    </v-toolbar>
    <v-btn color="success" @click="$router.push('/class/create/0')"><v-icon>add</v-icon> Novo</v-btn>
  <v-data-table
    :headers="headers"
    :items="classes"
    class="elevation-1"
    :hide-headers="isMobile" :class="{mobile: isMobile}">
    <template v-slot:items="classes">
      <tr v-if="!isMobile">
          <td>{{ classes.item.Code }}</td>
          <td>{{ classes.item.Period }}</td>
          <td>{{ classes.item.SemesterNumber }}</td>
          <td>{{ classes.item.Year }}</td>
          <td>
            <v-btn color="warning" @click="$router.push('/class/create/' + classes.item.Id)"><v-icon>edit</v-icon></v-btn>
          </td>
          <td>
            <v-btn color="error" @click="deleteItem(classes.item)"><v-icon>delete</v-icon></v-btn>
          </td>
      </tr>
      <tr v-else>
        <td>
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

import {Class} from "../../scripts/api_class"
var api = new Class();

export default {
    name: 'class',
    data() {
        return {
            isMobile: false,
            headers: [
                { text: 'Código', value: 'Code' },
                { text: 'Período', value: 'Period' },
                { text: 'Semestre', value: 'SemesterNumber' },
                { text: 'Ano', value: 'Year' },
                { text: '', value: '' },
                { text: '', value: '' },
            ],
            title: 'Turmas',
            classes: [],
            errorMessage: '',
            snackbar: false,
        };
    },
    beforeMount() {
        this.getClasses()
    },
    methods: {
        getClasses: function() {
          var vm = this;
          api.get({ success: function(e) { vm.classes = e; }});
        },
        deleteItem: function(item) {
          if(confirm("Deseja realmente excluir esse item?"))
          {
            var vm = this;
            api.delete({ path_params: [item.Id], 
              success: () => vm.getClasses(), 
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
