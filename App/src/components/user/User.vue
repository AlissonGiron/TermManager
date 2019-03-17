<template>
  <div>
    <v-toolbar color="white" style="background-color: red;">
      <v-btn icon light>
        <v-icon color="grey darken-2">arrow_back</v-icon>
      </v-btn>

      <v-toolbar-title class="grey--text text--darken-4">Usuários</v-toolbar-title>
    </v-toolbar>
    <v-btn color="success" @click="$router.push('/user/create')"><v-icon>add</v-icon> Novo</v-btn>
  <v-data-table
    :headers="headers"
    :items="users"
    class="elevation-1"
  >
    <template v-slot:items="users">
      <td>{{ users.item.Name }}</td>
      <td>{{ users.item.Email }}</td>
      <td>{{ users.item.AcademicTitle }}</td>
      <td><br><v-switch v-model='users.item.Administrator' readonly></v-switch></td>
      <td><br><v-switch v-model='users.item.Coordinator' readonly></v-switch></td>
      <td><br><v-switch v-model='users.item.Professor' readonly></v-switch></td>
      <td>
          <v-icon class="mr-2" @click="editItem(users.item)">
            edit
          </v-icon>
      </td>
      <td>
          <v-icon @click="deleteItem(users.item)">
            delete
          </v-icon>
      </td>
    </template>
  </v-data-table>
  </div>
</template>

<script>

import {User} from "../../scripts/apiUser"
var apiUser = new User();

export default {
    name: 'user',
    data() {
        return {
            headers: [
                { text: 'Nome', value: 'Name' },
                { text: 'Email', value: 'Email' },
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