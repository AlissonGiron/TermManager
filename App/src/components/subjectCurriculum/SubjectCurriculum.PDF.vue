<template>
    <div>
        <v-toolbar class="hidden-print" color="white" flat>
            <v-btn icon light>
            <v-icon @click="goback">arrow_back</v-icon>
            </v-btn>
        </v-toolbar>
        <v-btn class="hidden-print" color="success" @click="print()"><v-icon>print</v-icon>  Imprimir</v-btn>
        <div class="pdf">
            <p class="pdf-title">PLANO DE ENSINO</p>
            <p class="pdf-title">{{CourseName}}</p>
            <!-- Cabeçalho -->
            <table>
                <tr>
                    <td>Disciplina:</td>
                    <td class="text-center">{{SubjectName}}</td>
                    <td class="text-center" colspan="3"><b>Carga Horária</b></td>
                </tr>
                <tr>
                    <td>Professor:</td>
                    <td class="text-center">{{ProfessorName}}</td>
                    <td class="text-center b-all">Teoria</td>
                    <td class="text-center b-all">Prática</td>
                    <td class="text-center b-all">Total</td>
                </tr>
                <tr>
                    <td>E-mail:</td>
                    <td class="text-center">{{ProfessorEmail}}</td>
                    <td class="text-center b-all">{{TheoryWorkload}}</td>
                    <td class="text-center b-all">{{PracticalWorkload}}</td>
                    <td class="text-center b-all">{{TotalWorkload}}</td>
                </tr>
            </table>

            <br>

            <h3>Ementa:</h3>
            <p>{{model.Ementa}}</p>

            <br>
            <h3>Objetivos:</h3>
            <br>
            <p style="margin-left: 20px;" v-for="item in model.Goals">{{item.Description}}</p>
            <br>

            <p>Esta disciplina contribui com o desenvolvimento dos seguintes objetivos e competências
do egresso estabelecidos para o curso no PPC:</p>
            <br>
            <p style="margin-left: 20px;" v-for="item in model.Competences">{{item.Description}}</p>
            <br>

           <p>Para que tais objetivos sejam alcançados ao final desta disciplina os estudantes deverão
demonstras as seguintes competências e habilidades:</p>
            <br>
            <p style="margin-left: 20px;" v-for="item in model.Skills">{{item.Description}}</p>
            <br>

            <h3>Conteúdo Programático:</h3>
            <br>
            <div style="margin-left: 10px;">
              <h4>Módulo 1</h4>
              <p>{{model.ProgramContentM1}}</p>
            </div>
            <br>
            <div style="margin-left: 10px;">
              <h4>Módulo 2</h4>
              <p>{{model.ProgramContentM2}}</p>
            </div>
            <br>
            <h3>Metodologia de Ensino:</h3>
            <p style="margin-left: 20px;">{{model.TeachingMethod}}</p>
            <br>
            <h3>Avaliacao:</h3>
            <p style="margin-left: 20px;">{{model.Avaliacao}}</p>
            <br>
            <h3>Bibliografia Básica:</h3>
            <p style="margin-left: 20px;" v-for="item in model.BBibliography">{{item.Description}}</p>
            <br>
            <br>
            <h3>Bibliografia Complementar:</h3>
            <p style="margin-left: 20px;" v-for="item in model.CBibliography">{{item.Description}}</p>
            <br>
            <br>
            <h4 style="page-break-before: always;">Anexo 1</h4>
            <br>
            <p style="text-align: justify;"><b>Este documento deve ser complementado por ata do NDE aprovando o respectivo plano de
                ensino e referendando as bibliografias Básica e Complementar.</b></p>
                            <p><b>Modelo de Ata do NDE para referendar as Bibliografias</b>
                <br><br>
                <b>Ata de reunião do NDE</b><br>
                <b>Data da reunião:</b><br>
                <b>Local:</b><br>
                <br>
                <b>Pauta: Aprovação de Plano de Ensino</b>
                <br>
                <br>
                O Núcleo Docente Estruturante (NDE) do curso Engenharia de Computação , no uso de suas
                atribuições aprova o Plano de Ensino da disciplina Desenvolvimento de Aplicações para WEB e
                atesta que as bibliografias básica e Complementar são adequadas para a fundamentação
                e/ou complementação do respectivo conteúdo e está disponível em quantidade suficiente
                para o atendimento aos estudantes do curso e demais cursos que fazem uso da mesma.
                Anexa-se a esta ata Quantitativo Bibliográfico por componente curricular.
                As bibliografias virtuais são disponibilizadas a todos os estudantes e docentes sendo que não
                há restrições para acesso, são disponibilizados recursos tecnológicos para acesso aos títulos e
                leitura.<br>
                <br>
                Sorocaba, __/__/____
              </p>
              <br>
              <br>
              <br>
              <p style="border-bottom: 1px solid grey;" v-for="item in model.NDEMembers">{{item.Description}}</p>
              <br>
              <br>
              <br>
              <br>



      </div>
    </div>
</template>

<script>
import {SubjectCurriculum} from "../../scripts/api_subjectCurriculum"
  var api = new SubjectCurriculum();

  export default {
    name: 'subjectCurriculumPDF',
    props: {
        id: String
    },
    data: function() {
        return {
          title: "Plano de Ensino",
          gobackUrl: "/subjectCurriculum",
          CourseName: 'Computação',
          SubjectName: 'Teste',
          ProfessorName: 'Breda',
          ProfessorEmail: 'breda@gmail.com',
          TheoryWorkload: 0,
          PracticalWorkload: 0,
          TotalWorkload: 0,
          model: {
            Ementa: '',
            ProgramContentM1: '',
            ProgramContentM2: '',
            TeachingMethod: '',
            Avaliacao: '',
            Goals: [],
            Competences: [],
            Skills: [],
            NDEMembers: [],
            BBibliography: [],
            CBibliography: []
          },
        }
    },
    created() {
      var vm = this;
      
      if(parseInt(vm.id) > 0)
      {
         vm.getItem(vm.id);
      }
    },
    methods: {
      goback: function() {
        this.$router.push(this.gobackUrl);
      },
      getItem: function(id) {
        var vm = this;
        api.get({ path_params: [id], success: (data) => {
          vm.model.Skills = data.Model.Skills.map(function(e) { return e.Skill });
          vm.model.Goals = data.Model.Goals.map(function(e) { return e.Goal });
          vm.model.Competences = data.Model.Competences.map(function(e) { return e.Competence });
          vm.model.NDEMembers = data.Model.NDEMembers.map(function(e) { return e.NDEMember });
          vm.model.BBibliography = data.Model.Bibliography.filter(function(e) { return e.Type == 0; }).map(function(e) { return e.Book });
          vm.model.CBibliography = data.Model.Bibliography.filter(function(e) { return e.Type == 1; }).map(function(e) { return e.Book });
          vm.model.Ementa = data.Model.Ementa;
          vm.model.ProgramContentM1 = data.Model.ProgramContentM1;
          vm.model.ProgramContentM2 = data.Model.ProgramContentM2;
          vm.model.TeachingMethod = data.Model.TeachingMethod;
          vm.model.Avaliacao = data.Model.Avaliacao;

          vm.CourseName = data.Model.Course.Name;
          vm.SubjectName = data.Model.Subject.Name;
          vm.ProfessorName = data.Model.Professor.UserName;
          vm.ProfessorEmail = data.Model.Professor.Email;
          vm.TheoryWorkload = data.Model.Subject.TheoryWorkload;
          vm.PracticalWorkload = data.Model.Subject.PracticalWorkload;
          vm.TotalWorkload = vm.TheoryWorkload +  vm.PracticalWorkload;
        }});
      },
      print() {
        window.print();
      }
    }
  }
</script>

<style scoped>
    .pdf {
        font-family: Calibri;
        font-size: 11pt;

        padding: 0 50px;
    }

    p.pdf-title {
        width: 100%;
        font-family: Calibri;
        font-size: 20pt;
        font-weight: bold;
        text-align: center;
        color: #002060;
    }

    table {
        width: 100%;
    }

    table, th, tr, td.b-all {
        border: 1px solid black;
        border-collapse: collapse;
    }

    th {
        background-color: #002060;
        color: white;
        font-weight: normal;
    }

    th, td {
        padding: 3px;
    }

    .text-center {
        text-align: center;
    }

    .text-right {
        text-align: right;
    }

    hr.sign-line {
        max-width: 300px;
        margin: 0 auto;
    }

    @media print {
        .hidden-print {
            display: none;
        }

        .pdf {
            background: url('../../images/pdf_background.png') no-repeat center center;
            background-size: contain;
            padding: 160px 50px;

            width: 100vw;
            height: 100vh;
        }
    }
</style>
