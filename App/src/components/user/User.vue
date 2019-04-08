<template>
  <div>
    <v-toolbar color="white" style="background-color: red;">
      <v-btn icon light>
        <v-icon color="grey darken-2">arrow_back</v-icon>
      </v-btn>

      <v-toolbar-title class="grey--text text--darken-4">Usuários</v-toolbar-title>
    </v-toolbar>
    <v-btn color="success" @click="$router.push('/user/create/0')"><v-icon>add</v-icon> Novo</v-btn>
  <v-data-table
    :headers="headers"
    :items="users"
    class="elevation-1"
    :hide-headers="isMobile" :class="{mobile: isMobile}">
    <template v-slot:items="users">
      <tr v-if="!isMobile">
        <td>{{ users.item.UserName }}</td>
        <td>{{ users.item.AcademicTitle }}</td>
        <td><br><v-switch v-model='users.item.Administrator' readonly></v-switch></td>
        <td><br><v-switch v-model='users.item.Coordinator' readonly></v-switch></td>
        <td><br><v-switch v-model='users.item.Professor' readonly></v-switch></td>
        <td>
          <v-btn color="warning" @click="$router.push('/user/create/' + users.item.Id)"><v-icon>edit</v-icon></v-btn>
        </td>
        <td>
          <v-btn color="error" @click="deleteItem(users.item)"><v-icon>delete</v-icon></v-btn>
        </td>
      </tr>
      <tr v-else>
        <td>
          <v-layout row wrap>
            <v-flex xs6 data-label="Nome">
              {{ users.item.UserName }}
            </v-flex>
            <v-flex xs6 data-label="Email">
              {{ users.item.Email }}
            </v-flex>
            <v-flex xs6 data-label="Título">
              {{ users.item.AcademicTitle }}
            </v-flex>
            <v-flex xs6 data-label="">
              <v-switch v-model='users.item.Administrator' readonly></v-switch>
            </v-flex>
            <v-flex xs6 data-label="Coordenador">
              <v-switch v-model='users.item.Coordinator' readonly></v-switch>
            </v-flex>
            <v-flex xs6 data-label="Professor">
              <v-switch v-model='users.item.Professor' readonly></v-switch>
            </v-flex>
          </v-layout>
        </td>
      </tr>
    </template>
  </v-data-table>
  </div>
</template>

<script>

import {User} from "../../scripts/api_user"
var apiUser = new User();

export default {
    name: 'user',
    data() {
        return {
            isMobile: false,
            headers: [
                { text: 'Nome', value: 'UserName' },
                { text: 'Título', value: 'AcademicTitle' },
                { text: 'Administrador', value: 'Administrator' },
                { text: 'Coordenador', value: 'Coordinator' },
                { text: 'Professor', value: 'Professor' },
                { text: ' ', value: ' ' },
                { text: ' ', value: ' ' },
            ],
            title: 'Usuários',
            users: []
        };
    },
    beforeMount() {
        this.getUsers()
    },
    methods: {
        getUsers: function() {
          var vm = this;
          apiUser.get({ success: function(e) { vm.users = e; }});
        },
        deleteItem: function(item) {
          if(confirm("Deseja realmente excluir esse item?"))
          {
            var vm = this;
            apiUser.delete({ path_params: [item.Id], success: () => vm.getUsers() });
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
