pipeline {
    agent any
    environment {
        CARPETA_APLICACION = './'
        ASPNETCORE_ENVIRONMENT = 'Development'
    }

    stages {
        stage('Run docker compose') {
            steps {
                dir("${CARPETA_APLICACION}") {
                    sh 'docker compose up -d'
                }
            }
        }

    }
}