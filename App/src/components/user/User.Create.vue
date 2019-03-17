<template>
  <div>
    <v-toolbar color="white" flat>
          <v-btn icon light>
            <v-icon color="grey darken-2">arrow_back</v-icon>
          </v-btn>

          <v-toolbar-title class="grey--text text--darken-4">Usuário</v-toolbar-title>
    </v-toolbar>

      <v-container grid-list-sm class="pa-4">
        <div class="xs6">
          <v-layout row wrap>
            <v-flex xs12>
              <v-text-field v-model="user.name" label="Nome"></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field v-model="user.email" label="Email"></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field v-model="user.academicTitle" label="Título"></v-text-field>
            </v-flex>
            <v-flex xs4>
              <v-switch v-model="user.administrator" label="Administrador"></v-switch>
            </v-flex>
            <v-flex xs4>
              <v-switch v-model="user.coordinator" label="Coordenador"></v-switch>
            </v-flex>
            <v-flex xs4>
              <v-switch v-model="user.professor" label="Professor"></v-switch>
            </v-flex>
          </v-layout>
          <v-btn color="success" @click="createUser">Salvar</v-btn>
        </div>
      </v-container>
  </div>
</template>

<script>

  import {User} from "../../scripts/apiUser"
  var apiUser = new User();

  export default {
    name: 'userCreate',
    data: function() {
        return {
          user: {
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
        this.getUser(16);
    },
    methods: {
      createUser: function() {
        apiUser.post({ data: this.user });
      },
      getUser: function(id) {
        var vm = this;
        apiUser.get({ path_params: [id], success: (data) => { vm.user = data; } });
      }
    }
  }
</script>