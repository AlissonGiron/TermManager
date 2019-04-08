<template>
  <v-app>
    <div class="bg"></div>
    <v-container fluid fill-height>
      <v-layout align-center justify-center>
        <v-flex xs12 sm8 md4>
          <v-card class="elevation-12">
            <v-toolbar dark color="primary">
              <v-toolbar-title>Gerenciador de Aulas - Login</v-toolbar-title>
            </v-toolbar>
            <v-card-text>
              <v-form>
                <v-text-field prepend-icon="person" id="username" name="login" label="Usuário" type="text" autocomplete="username"></v-text-field>
                <v-text-field
                  prepend-icon="lock"
                  name="password"
                  label="Senha"
                  id="password"
                  type="password"
                  autocomplete="current-password"
                ></v-text-field>
              </v-form>
            </v-card-text>
            <v-card-actions>
              <v-spacer></v-spacer>
              <v-btn color="primary" @click="login">Login</v-btn>
            </v-card-actions>
          </v-card>
        </v-flex>
      </v-layout>
    </v-container>
  </v-app>
</template>

<script>
import {Login} from '../scripts/api_login.js'
var api_login = new Login();

export default {
  methods: {
    login: function() {
        let data = {
          userName: document.getElementById('username').value,
          password: document.getElementById('password').value
        }

        api_login.login(this.$root, data.userName, data.password);
    }
  }
};
</script>