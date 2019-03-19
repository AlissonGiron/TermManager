<template>
  <div>
    <v-toolbar color="white" flat>
        <v-btn icon light>
          <v-icon @click="$router.push('/user')">arrow_back</v-icon>
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
          <v-btn v-if="this.user_id" color="success" @click="createUser">Salvar</v-btn>
          <v-btn v-else color="success" @click="editUser">Salvar</v-btn>
        </div>
      </v-container>
  </div>
</template>

<script>

  import {User} from "../../scripts/apiUser"
  var apiUser = new User();

  export default {
    name: 'userCreate',
    props: {
        user_id: Number
    },
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
      if(this.user_id)
      {
        this.getUser(this.user_id);
      }
    },
    methods: {
      createUser: function() {
        var vm = this;
        apiUser.post({ 
          data: this.user, 
          success: () => { 
            alert("Usuário salvo com sucesso")
            vm.$router.push('/user') 
          }
        }); 
      },
      createUser: function() {
        var vm = this;
        apiUser.put({
          data: this.user, 
          path_params: [this.user.id],
          success: () => { 
            alert("Usuário editado com sucesso")
            vm.$router.push('/user') 
          }
        }); 
      },
      getUser: function(id) {
        var vm = this;
        apiUser.get({ path_params: [id], success: (data) => { vm.user = data; } });
      }
    }
  }
</script>