<template>
    <div>
        <v-toolbar class="hidden-print" color="white" flat>
            <v-btn icon light>
            <v-icon @click="goback">arrow_back</v-icon>
            </v-btn>
        </v-toolbar>
        <div class="classPlan">
            <p class="classPlan-title">PLANO DE AULAS</p>
            <p class="classPlan-title">[CURSO] - [ANO]/[SEMESTRE]º Semestre</p>
            <!-- Cabeçalho -->
            <table>
                <tr>
                    <td>Disciplina:</td>
                    <td class="text-center">[DISCIPLINA]</td>
                    <td class="text-center" colspan="3">Carga Horária</td>
                </tr>
                <tr>
                    <td>Professor:</td>
                    <td class="text-center">[PROFESSOR]</td>
                    <td class="text-center b-all">Teoria</td>
                    <td class="text-center b-all">Prática</td>
                    <td class="text-center b-all">Total</td>
                </tr>
                <tr>
                    <td>E-mail:</td>
                    <td class="text-center">[EMAIL]</td>
                    <td class="text-center b-all">[CHTEORIA]</td>
                    <td class="text-center b-all">[CHPRATICA]</td>
                    <td class="text-center b-all">[CHTOTAL]</td>
                </tr>
                <tr>
                    <td>Turma: [TURMA]</td>
                    <td class="text-right" colspan="4">Coordenador(a) [COORDENADOR]</td>
                </tr>
            </table>
            
            <!-- Aulas -->
            <table>
                <th>Semana</th>
                <th>Data</th>
                <th>Teoria ou Prática</th>
                <th>Conteúdo</th>
                <th>Bibliografia</th>
            </table>

            <!-- Bibliografia -->
            <table>
                <th>Item</th>
                <th>Tipo*</th>
                <th>Bibliografia</th>

                <tr>
                    <td colspan="3">Tipo: B - Básica | C - Complementar</td>
                </tr>
            </table>

            <!-- Notas -->
            <table>
                <th colspan="3">Composição das Notas</th>
                <tr>
                    <td class="text-center b-all">Atividade</td>
                    <td class="text-center b-all">Descrição</td>
                    <td class="text-center b-all">Peso</td>
                </tr>

                <tr>
                    <td colspan="3">[DESCRICAO FINAL NOTAS]</td>
                </tr>
            </table>

            <!-- Recursos -->
            <table>
                <th>Data</th>
                <th>Recursos necessários</th>
            </table>

            <p class="text-center">Sorocaba, [DATA]</p>
            <br>
            <hr class="sign-line">
            <p class="text-center">Ass. Professor</p>
            <br>
            <hr class="sign-line">
            <p class="text-center">Ass. Coordenador</p>
        </div>
    </div>
</template>

<script>
  export default {
    name: 'classPlanPrint',
    props: {
        id: String
    },
    data: function() {
        return {
          title: "Plano de Aula",
          gobackUrl: "/classPlan",
          model: {
            id: 0
          }
        }
    },
    methods: {
      goback: function() {
        this.$router.push(this.gobackUrl);
      }
    }
  }
</script>

<style scoped>
    .classPlan {
        font-family: Calibri;
        font-size: 11pt;

        padding: 0 50px;
    }

    p.classPlan-title {
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

        .classPlan {
            background: url('../../images/pdf_background.png') no-repeat center center;
            background-size: contain;
            padding: 160px 50px;

            width: 100vw;
            height: 100vh;
        }
    }
</style>
