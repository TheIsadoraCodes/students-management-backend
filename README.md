# Students Manager API (Desafio DTI Digital)

Projeto em ASP.NET Core (.NET 8) que gerencia informações de alunos, notas por disciplina e frequência. Fornece endpoints para adicionar alunos e retornar estatísticas da turma.

## Requisitos
- .NET 8 SDK

## Como executar
1. Abra um terminal na pasta do projeto
2. Restaure e execute com o CLI:

```bash
dotnet restore
dotnet run
```

O projeto estará disponível em `https://localhost:7277` (ou conforme configurado).

## Endpoints
- `POST /api/student/add` — Adiciona um aluno
  - Corpo (JSON):
    ```json
    {
      "name": "João",
      "grades": [
        { "subjectName": "Mathematics", "grade": 8.5 },
        { "subjectName": "History", "grade": 7.0 }
      ],
      "attendance": 92.5
    }
    ```
  - Retorna o objeto `Student` criado.

- `GET /api/student/get` — Retorna dados gerais da turma (médias por aluno, média por disciplina, alunos acima da média e alunos com baixa frequência)
  - Retorna `ResultResponseDto` com as seguintes propriedades:
    - `StudentAverages`: lista de médias por aluno
    - `ClassAverageBySubject`: média da turma por disciplina
    - `StudentsAboveClassAverage`: alunos acima da média por disciplina
    - `StudentsWithLowAttendance`: alunos com frequência abaixo de 75%

## Estrutura de Pastas

```
StudentsManager/
├── Controllers/
│   └── StudentController.cs          # Endpoints da API
├── DTOs/
│   ├── StudentRequestDto.cs          # DTO para adicionar aluno
│   ├── StudentAverageResponseDto.cs  # DTO de média por aluno
│   ├── StudentAboveAverageDto.cs     # DTO de aluno acima da média
│   ├── StudentLowAttendanceDto.cs    # DTO de aluno com baixa frequência
│   ├── MediaTurmaDto.cs              # DTO de média da turma
│   └── ResultResponseDto.cs          # DTO de resposta agregada
├── Models/
│   ├── Student.cs                    # Modelo de Aluno
│   └── SubjectGrade.cs               # Modelo de Nota por Disciplina
├── Services/
│   └── StudentService.cs             # Lógica de negócios
├── Program.cs                        # Configuração da aplicação
└── StudentsManager.csproj            # Arquivo de projeto
```

## Modelos principais
- `StudentRequestDto` — entrada para criar aluno (`Name`, `Grades`, `Attendance`)
- `SubjectGrade` — nota por disciplina (`SubjectName`, `Grade`)
- `Student` — modelo de aluno com propriedades completas
- `ResultResponseDto` — resposta agregada usada no endpoint GET

## Exemplo cURL
```bash
curl -X POST "https://localhost:5001/api/student/add" \
  -H "Content-Type: application/json" \
  -d '{"name":"Maria","grades":[{"subjectName":"Math","grade":9}],"attendance":88}'

curl "https://localhost:5001/api/student/get"
```

## Observações
- O projeto armazena dados em memória (`StudentService`), portanto os dados são perdidos ao reiniciar a aplicação.
- O namespace utilizado é `Students` (DTOs, Models, Services, Controllers)
- A API inclui Swagger para documentação interativa em `/swagger/index.html`
- Direcionado para uso de demonstração e testes locais.

## Contribuições
Abrir issues ou pull requests para melhorias.
