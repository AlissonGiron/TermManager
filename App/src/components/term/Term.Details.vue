<template>
  <div>
    <v-toolbar color="white" flat>
        <v-btn icon light>
          <v-icon @click="goback">arrow_back</v-icon>
        </v-btn>

        <v-toolbar-title class="grey--text text--darken-4">{{ title }}</v-toolbar-title>
    </v-toolbar>

      <v-container grid-list-sm class="pa-4">
        <div class="xs6">
          <v-layout id="fields" row wrap>
            <v-flex xs6>
              <v-text-field type="number" v-model="model.SemesterNumber" label="Número do Semestre"></v-text-field>
            </v-flex>
            <v-flex xs6>
              <v-text-field type="number" v-model="model.Year" label="Ano"></v-text-field>
            </v-flex>
          </v-layout>
          <v-btn v-if="this.id > 0" color="warning" @click="edit">Salvar</v-btn>
          <v-btn v-else color="success" @click="create">Salvar</v-btn>
        </div>
      </v-container>
  </div>
</template>

<script>
  import {Term} from "../../scripts/api_term"
  var api = new Term();

  export default {
    name: 'termDetails',
    props: {
        id: Number
    },
    data: function() {
      return {
        title: "Semestre",
        gobackUrl: "/term",
        model: {
          id: 0,
          SemesterNumber: 0,
          Year: 0,
        }
      }
    },
    created() {
      if(this.id > 0)
      {
        this.getItem(this.id);
      }
    },
    methods: {
      create: function() {
        var vm = this;
        api.post({ 
          data: this.model,
          success: (data) => { 
            vm.$router.push('/term/create/' + data.id)
          }
        });
      },
      edit: function() {
        var vm = this;
        api.put({
          data: this.model, 
          path_params: [this.model.id],
          success: () => { 
            alert("Item editado com sucesso");
            vm.$router.push(vm.gobackUrl);
          }
        }); 
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