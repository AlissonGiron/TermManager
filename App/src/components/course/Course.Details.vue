<template>
  <div>
    <v-toolbar color="white" flat>
        <v-btn icon light>
          <v-icon @click="goback">arrow_back</v-icon>
        </v-btn>

        <v-toolbar-title class="grey--text text--darken-4">{{ title }}</v-toolbar-title>
    </v-toolbar>

    <v-container style='background-color: white;' class="pa-4">
      <div class="xs6">
        <v-form v-model="valid">
          <v-layout id="fields" row wrap>
              <v-flex xs12>
                <v-text-field v-model="model.Code" 
                              label="Código"
                              :validate-on-blur='true' :rules="[() => !!model.Code || 'Esse campo é obrigatório']">
                </v-text-field>
              </v-flex>
              <v-flex xs12>
                <v-text-field v-model="model.Name"
                              label="Nome"
                              :validate-on-blur='true' :rules="[() => !!model.Name || 'Esse campo é obrigatório']">
                </v-text-field>
              </v-flex>
          </v-layout>
        </v-form>

        <v-tabs v-if="this.id > 0" dark slider-color="orange">
          <v-tab ripple>
            Disciplinas
          </v-tab>
          <v-tab>
            Habilidades
          </v-tab>
          <v-tab>
            Objetivos
          </v-tab>
          <v-tab>
            Competências
          </v-tab>
          
          <v-tab-item>
            <v-card flat>
              <v-card-text>
                 <v-autocomplete v-model="selected_disciplines" :items="disciplines" multiple label="Disciplinas" item-text="name" item-value="id">
                    <template v-slot:selection="data">
                      <v-chip :selected="data.selected" close class="chip--select-multi" @input="remove(data.item)">
                        {{ data.item.name }}
                      </v-chip>
                    </template>
                    <template v-slot:item="data">
                        <v-list-tile-content v-text="data.item.name"></v-list-tile-content>
                    </template>
                  </v-autocomplete>
              </v-card-text>
            </v-card>
          </v-tab-item>
          
          <v-tab-item>
            <v-card flat>
              <v-card-text>
                <v-btn color="success" @click="skill = {}; dialog_Skill = true"><v-icon>add</v-icon> Nova Habilidade</v-btn>
                <v-data-table :headers="headers" :items="skills">
                  <template v-slot:items="skills">
                    <tr>
                        <td>{{ skills.item.Description }}</td>
                        <td>
                          <v-btn @click="openEditSkill(skills.item)" color="warning"><v-icon>edit</v-icon></v-btn>
                        </td>
                        <td>
                          <v-btn @click="deleteSkill(skills.item.Id)" color="error"><v-icon>delete</v-icon></v-btn>
                        </td>
                    </tr>
                  </template>
                </v-data-table>
              </v-card-text>
            </v-card>
          </v-tab-item>

          <v-tab-item>
            <v-card flat>
              <v-card-text>
                <v-btn color="success" @click="goal = {}; dialog_Goal = true"><v-icon>add</v-icon> Novo Objetivo</v-btn>
                <v-data-table :headers="headers" :items="goals">
                  <template v-slot:items="goals">
                    <tr>
                        <td>{{ goals.item.Description }}</td>
                        <td>
                          <v-btn @click="openEditGoal(goals.item)" color="warning"><v-icon>edit</v-icon></v-btn>
                        </td>
                        <td>
                          <v-btn @click="deleteGoal(goals.item.Id)" color="error"><v-icon>delete</v-icon></v-btn>
                        </td>
                    </tr>
                  </template>
                </v-data-table>
              </v-card-text>
            </v-card>
          </v-tab-item>
          
          <v-tab-item>
            <v-card flat>
              <v-card-text>
                <v-btn color="success" @click="competence = {}; dialog_Competence = true"><v-icon>add</v-icon> Nova Competência</v-btn>
                <v-data-table :headers="headers" :items="competences">
                  <template v-slot:items="competences">
                    <tr>
                        <td>{{ competences.item.Description }}</td>
                        <td>
                          <v-btn @click="openEditCompetence(competences.item)" color="warning"><v-icon>edit</v-icon></v-btn>
                        </td>
                        <td>
                          <v-btn @click="deleteCompetence(competences.item.Id)" color="error"><v-icon>delete</v-icon></v-btn>
                        </td>
                    </tr>
                  </template>
                </v-data-table>
              </v-card-text>
            </v-card>
          </v-tab-item>
        </v-tabs>

        <v-btn v-if="this.id > 0" color="warning" @click="edit">Editar</v-btn>
        <v-btn v-else color="success" @click="create">Salvar</v-btn>
      </div>
    </v-container>

    <v-layout row justify-center>
      <v-dialog v-model="dialog_Skill" persistent max-width="600px">
        <v-card>
          <v-card-title>
            <span class="headline">Habilidade</span>
          </v-card-title>
          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12>
                  <v-form v-model="skill_valid">
                    <v-text-field v-model="skill.Description" label="Descrição" :validate-on-blur='true' :rules="[() => !!skill.Description || 'Esse campo é obrigatório']"></v-text-field>
                  </v-form>
                </v-flex>
              </v-layout>
            </v-container>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click="dialog_Skill = false">Cancelar</v-btn>
            <v-btn color="blue darken-1" flat @click="saveSkill()">Salvar</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-layout>

    <v-layout row justify-center>
      <v-dialog v-model="dialog_Goal" persistent max-width="600px">
        <v-card>
          <v-card-title>
            <span class="headline">Objetivo</span>
          </v-card-title>
          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12>
                  <v-form v-model="goal_valid">
                    <v-text-field v-model="goal.Description" label="Descrição" :validate-on-blur='true' :rules="[() => !!goal.Description || 'Esse campo é obrigatório']"></v-text-field>
                  </v-form>
                </v-flex>
              </v-layout>
            </v-container>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click="dialog_Goal = false">Cancelar</v-btn>
            <v-btn color="blue darken-1" flat @click="saveGoal()">Salvar</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-layout>

    <v-layout row justify-center>
      <v-dialog v-model="dialog_Competence" persistent max-width="600px">
        <v-card>
          <v-card-title>
            <span class="headline">Competência</span>
          </v-card-title>
          <v-card-text>
            <v-container grid-list-md>
              <v-layout wrap>
                <v-flex xs12>
                  <v-form v-model="competence_valid">
                    <v-text-field v-model="competence.Description" label="Descrição" :validate-on-blur='true' :rules="[() => !!competence.Description || 'Esse campo é obrigatório']"></v-text-field>
                  </v-form>                
                </v-flex>
              </v-layout>
            </v-container>
          </v-card-text>
          <v-card-actions>
            <v-spacer></v-spacer>
            <v-btn color="blue darken-1" flat @click="dialog_Competence = false">Cancelar</v-btn>
            <v-btn color="blue darken-1" flat @click="saveCompetence()">Salvar</v-btn>
          </v-card-actions>
        </v-card>
      </v-dialog>
    </v-layout>

  </div>
</template>

<script>
  import { Course } from '../../scripts/api_course';
  var api = new Course();

  export default {
    name: 'courseDetails',
    props: {
        id: Number
    },
    data: function() {
        return {
          valid: true,
          skill_valid: true,
          goal_valid: true,
          competence_valid: true,
          title: "Curso",
          dialog_Skill: false,
          dialog_Competence: false,
          dialog_Goal: false,
          gobackUrl: "/course",
          headers: [
              { text: 'Descrição', value: 'Name' },
              { text: 'Editar', value: 'Edit' },
              { text: 'Excluir', value: 'Delete' },
          ],
          skills: [],
          competences: [],
          goals: [],
          selected_disciplines: [],
          disciplines: [],
          skill: { Description: '' },
          competence: { Description: '' },
          goal: { Description: '' },
          model: {
            id: 0,
            Name: '',
            Code: ''
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
        if(!this.valid) return;
        var vm = this;
        api.post({ 
          data: this.model,
          success: (data) => { 
            vm.$router.push('/course/create/' + data.id)
          }
        });
      },
      remove (item) {
        const index = this.selected_disciplines.indexOf(item.id)
        if (index >= 0) this.selected_disciplines.splice(index, 1)
      },
      edit: function() {
        var vm = this;
        api.saveSubjects(this.id, this.selected_disciplines, (data) => 
        { 
          api.put({
            data: vm.model, 
            path_params: [vm.id],
            success: () => { 
              alert("Item editado com sucesso");
              vm.$router.push(vm.gobackUrl);
            }
          }); 
        })
      },
      getItem: function(id) {
        var vm = this;
        api.get({ path_params: [id], success: (data) => 
        { 
            vm.model = data;
            vm.readSkills();
            vm.readGoals();
            vm.readCompetences();
            vm.readSubjects();

            api.readSubjects(vm.id, (data) => 
            { 
              vm.selected_disciplines = data.map(function(e) { return e.Id; }) 
            })
        }});
      },
      goback: function() {
        var vm = this;
        this.$router.push(vm.gobackUrl);
      },

      // subjects
      readSubjects: function() {
        var vm = this;
        api.readSubjects(0, (data) => 
        { 
          vm.disciplines = data.map(function(e) { return { id: e.Id, name: [e.Code, e.Name].join(" | ") } }) 
        })
      },

      // skills
      readSkills: function() {
        var vm = this;
        vm.dialog_Skill = false;
        api.readSkills(this.id, (data) => { vm.skills = data })
      },
      openEditSkill: function(skill) {
         this.skill = skill;
         this.dialog_Skill = true;
      },
      saveSkill: function() {
        if(!this.skill_valid) return;

        var vm = this;

        if(this.skill.Id)
        {
          api.editSkill(this.skill.Id, this.skill, (data) => { vm.readSkills() })
        }
        else {
          api.createSkill(this.id, this.skill, (data) => { vm.readSkills() })
        }
      },
      deleteSkill: function(id) {
        var vm = this;
        api.deleteSkill(id, (data) => { vm.readSkills() })
      },

      // goals
      readGoals: function() {
        var vm = this;
        vm.dialog_Goal = false;
        api.readGoals(this.id, (data) => { vm.goals = data })
      },
      openEditGoal: function(goal) {
         this.goal = goal;
         this.dialog_Goal = true;
      },
      saveGoal: function() {
        if(!this.goal_valid) return;
        
        var vm = this;

        if(this.goal.Id)
        {
          api.editGoal(this.goal.Id, this.goal, (data) => { vm.readGoals() })
        }
        else {
          api.createGoal(this.id, this.goal, (data) => { vm.readGoals() })
        }
      },
      deleteGoal: function(id) {
        var vm = this;
        api.deleteGoal(id, (data) => { vm.readGoals() })
      },
      
      // competences
      readCompetences: function() {
        var vm = this;
        vm.dialog_Competence = false;
        api.readCompetences(this.id, (data) => { vm.competences = data })
      },
      openEditCompetence: function(competence) {
         this.competence = competence;
         this.dialog_Competence = true;
      },
      saveCompetence: function() {
        if(!this.competence_valid) return;
        
        var vm = this;

        if(this.competence.Id)
        {
          api.editCompetence(this.competence.Id, this.competence, (data) => { vm.readCompetences() })
        }
        else {
          api.createCompetence(this.id, this.competence, (data) => { vm.readCompetences() })
        }
      },
      deleteCompetence: function(id) {
        var vm = this;
        api.deleteCompetence(id, (data) => { vm.readCompetences() })
      },
    }
  }
</script>

<style>
  .erro {
    color: red;
  }
</style>
