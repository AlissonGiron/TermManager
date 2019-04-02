<template>
  <v-app>
    <v-navigation-drawer v-model="drawer" fixed app dark>
      <v-list>
        <template v-for="item in menu">
          <v-list-tile v-bind:key="item.text" @click="$router.push(item.route)">
            <v-list-tile-action>
              <v-icon>{{ item.icon }}</v-icon>
            </v-list-tile-action>
            <v-list-tile-content>
              <v-list-tile-title>
                {{ item.text }}
              </v-list-tile-title>
            </v-list-tile-content>
          </v-list-tile>
        </template>
      </v-list>
    </v-navigation-drawer>
    <v-toolbar app fixed dark>
      <v-toolbar-title style="width: 300px" @click="$router.push('/')" class="unifacens_home">
        <v-toolbar-side-icon @click.stop="drawer = !drawer"></v-toolbar-side-icon>
        <v-avatar size="32px" tile>
          <img src="../images/icone_unifacens.png" alt="UniFacens logo">
        </v-avatar>
        <span class="hidden-sm-and-down">Gerenciador de Aulas</span>
      </v-toolbar-title>
      <v-spacer></v-spacer>
      <span class="hidden-sm-and-down">Alisson</span>
      <v-btn icon>
        <v-icon>person_pin</v-icon>
      </v-btn>
    </v-toolbar>
    <v-content dark>
      <div fluid fill-height>
          <router-view></router-view>
      </div>
    </v-content>
  </v-app>
</template>

<script>
  export default {
    data: () => ({
      name: 'layout',
      drawer: null,
      menu: [
        { icon: 'home', text: 'Início', route: '/' },
        { icon: 'person', text: 'Usuários', route: '/user' },
        { icon: 'person', text: 'Cursos', route: '/course' },
        { icon: 'person', text: 'Semestres', route: '/term' },
        { icon: 'person', text: 'Disciplinas', route: '/subject' },
        { icon: 'transit_enterexit', text: 'Sair', route: '/' }
      ]
    })
  }
</script>

<style>
    .unifacens_home:hover {
        cursor: pointer;
    }

    .unifacens_content {
        background-color: #222129;
        color: white;
    }
</style>
