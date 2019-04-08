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
        <v-form ref="form">
          <v-layout id="fields" row wrap>
            <v-flex xs6>
              <v-select 
                v-model="model.SemesterNumber"
                :items="semesters"
                label="Selecione um semestre do ano"
              ></v-select>
            </v-flex>
            <v-flex xs6>
              <v-text-field type="number" v-model="model.Year" label="Ano" :validate-on-blur='true' :rules="[(v) => !!v || 'Esse campo é obrigatório', (v) => !(parseInt(v) < 0) || 'Digite um valor maior que 0']"></v-text-field>
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
      Esse semestre já está cadastrado
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
    name: 'termDetails',
    props: {
        id: String
    },
    data: function() {
      return {
        title: "Semestre",
        gobackUrl: "/term",
        snackbar: false,
        model: {
          id: 0,
          SemesterNumber: 1,
          Year: 0,
        },
        semesters: [1, 2]
      }
    },
    created() {
      if(parseInt(this.id) > 0)
      {
        this.getItem(parseInt(this.id));
      }
    },
    methods: {
      create: function() {
        if(!this.$refs.form.validate()) return;

        var vm = this;

        api.checkTermExists(0, vm.model.SemesterNumber, vm.model.Year, function(status) {
          if(status)
          {
             vm.snackbar = true;
             return;
          }

          api.post({ 
            data: vm.model,
            success: (data) => { 
              alert("Item salvo com sucesso");
              vm.$router.push(vm.gobackUrl);
            }
          });
        })
      },
      edit: function() {
        if(!this.$refs.form.validate()) return;

        var vm = this;

        api.checkTermExists(vm.model.Id, vm.model.SemesterNumber, vm.model.Year, function(status) {
          if(status)
          {
             vm.snackbar = true;
             return;
          }

          api.put({
            data: vm.model, 
            path_params: [vm.model.id],
            success: () => { 
              alert("Item editado com sucesso");
              vm.$router.push(vm.gobackUrl);
            }
          }); 
        })
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