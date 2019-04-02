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
            <v-flex xs12>
              <v-text-field v-model="model.Code" label="Código"></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field v-model="model.Name" label="Nome"></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field v-model="model.TheoryWorkLoad" label="Carga Horária (Teoria)"></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field v-model="model.PracticalWorload" label="Carga Horária (Prática)"></v-text-field>
            </v-flex>
          </v-layout>
          <v-btn v-if="this.id > 0" color="warning" @click="edit">Salvar</v-btn>
          <v-btn v-else color="success" @click="create">Salvar</v-btn>
        </div>
      </v-container>
  </div>
</template>

<script>
  import {Subject} from "../../scripts/api_subject"
  var api = new Subject();

  export default {
    name: 'subjectDetails',
    props: {
        id: Number
    },
    data: function() {
        return {
          title: "Disciplina",
          gobackUrl: "/subject",
          model: {
            id: 0,
            Name: '',
            Code: '',
            TheoryWorkload: 0,
            PracticalWorkload: 0,
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
          success: () => { 
            alert("Item salvo com sucesso");
            vm.$router.push(vm.gobackUrl);
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