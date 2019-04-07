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
        <v-form ref="form" v-model="valid">

          <v-layout id="fields" row wrap>
            <v-flex xs12>
              <v-text-field v-model="model.Code" label="Código" :validate-on-blur='true' :rules="[() => !!model.Code || 'Esse campo é obrigatório']"></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field v-model="model.Name" label="Nome" :validate-on-blur='true' :rules="[() => !!model.Name || 'Esse campo é obrigatório']"></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field type="number" v-model="model.TheoryWorkload" label="Carga Horária (Teoria)"></v-text-field>
            </v-flex>
            <v-flex xs12>
              <v-text-field type="number" v-model="model.PracticalWorkload" label="Carga Horária (Prática)"></v-text-field>
            </v-flex>
            <v-flex xs12>
              <br>
              <p>Responsável pelo Plano de Ensino</p>
              <v-select 
                v-model="model.IdTeacherTeachingPlan"
                item-value="id"
                item-text="name" 
                :items="professors"
                label="Professor"
                solo
              ></v-select>
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
        Selecione um professor responsável pelo plano de ensino
        <v-btn dark flat @click="snackbar = false">
          Ok
        </v-btn>
      </v-snackbar>
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
          snackbar: false,
          model: {
            id: 0,
            Name: '',
            Code: '',
            TheoryWorkload: 0,
            PracticalWorkload: 0,
            IdTeacherTeachingPlan: 0
          },
          professors: []
        }
    },
    created() {
      var vm = this;
      
      if(parseInt(vm.id) > 0)
      {
        vm.getItem(vm.id);
        this.readProfessors(vm.id);
      }
      else {
        this.readProfessors(0);
      }

    },
    methods: {
      create: function() {
        var isValid = this.$refs.form.validate();

        if(this.model.IdTeacherTeachingPlan == 0)
        {
          this.snackbar = true;
          isValid = false;
        }
        
        if(!isValid) return;

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
        var isValid = this.$refs.form.validate();

        if(this.model.IdTeacherTeachingPlan == 0)
        {
          this.snackbar = true;
          isValid = false;
        }
        
        if(!isValid) return;

        var vm = this;
        api.put({
          data: this.model, 
          path_params: [this.model.Id],
          success: () => { 
            alert("Item editado com sucesso");
            vm.$router.push(vm.gobackUrl);
          }
        }); 
      },
      readProfessors: function(id) {
        var vm = this;

        api.readProfessors(id, function(data) {
          vm.professors = data.map(function(e) { return { id: e.Id, name: e.Name } });
        });
      },
      getItem: function(id) {
        var vm = this;
        api.get({ path_params: [id], success: (data) => { debugger;
        vm.model = data; } });
      },
      goback: function() {
        this.$router.push(this.gobackUrl);
      }
    }
  }
</script>