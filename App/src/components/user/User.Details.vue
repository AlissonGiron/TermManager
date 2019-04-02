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
              <v-text-field v-model="model.name" label="Nome"></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field v-model="model.email" label="Email"></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field v-model="model.academicTitle" label="Título"></v-text-field>
            </v-flex>
            <v-flex xs4>
              <v-switch v-model="model.administrator" label="Administrador"></v-switch>
            </v-flex>
            <v-flex xs4>
              <v-switch v-model="model.coordinator" label="Coordenador"></v-switch>
            </v-flex>
            <v-flex xs4>
              <v-switch v-model="model.professor" label="Professor"></v-switch>
            </v-flex>
          </v-layout>
          <v-btn v-if="this.id" color="warning" @click="edit">Salvar</v-btn>
          <v-btn v-else color="success" @click="create">Salvar</v-btn>
        </div>
      </v-container>
  </div>
</template>

<script>
  import {User} from "../../scripts/api_user"
  var api = new User();

  export default {
    name: 'userDetails',
    props: {
        id: Number
    },
    data: function() {
        return {
          title: "Usuário",
          gobackUrl: "/user",
          model: {
            id: 0,
            name: '',
            email: '',
            academicTitle: '',
            administrator: false,
            coordinator: false,
            professor: false
          }
        }
    },
    created() {
      if(this.id)
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