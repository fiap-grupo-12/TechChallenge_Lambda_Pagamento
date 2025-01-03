provider "aws" {
  region = "us-east-1"
}

terraform {
  backend "s3" {
    bucket = "terraform-tfstate-grupo12-fiap-2024"
    key    = "lambda_pagamento/terraform.tfstate"
    region = "us-east-1"
  }
}

# Fila SQS - sqs_atualiza_pagamento_pedido
data "aws_sqs_queue" "atualiza_pagamento" {
  name = "sqs_atualiza_pagamento_pedido"
}

resource "aws_iam_role" "lambda_execution_role" {
  name = "lambda_pagamento_execution_role"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Action = "sts:AssumeRole"
        Effect = "Allow"
        Principal = {
          Service = "lambda.amazonaws.com"
        }
      },
    ]
  })
}

resource "aws_iam_policy" "lambda_policy" {
  name        = "lambda_pagamento_policy"
  description = "IAM policy for Lambda execution"
  policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Effect = "Allow"
        Action = [
          "logs:CreateLogGroup",
          "logs:CreateLogStream",
          "logs:PutLogEvents",
          "dynamodb:DeleteItem",
          "dynamodb:GetItem",
          "dynamodb:PutItem",
          "dynamodb:Query",
          "dynamodb:Scan",
          "dynamodb:UpdateItem",
          "dynamodb:DescribeTable",
          "sqs:*"
        ]
        Resource = "*"
      }
    ]
  })
}

resource "aws_iam_role_policy_attachment" "lambda_execution_policy" {
  role       = aws_iam_role.lambda_execution_role.name
  policy_arn = aws_iam_policy.lambda_policy.arn
}

resource "aws_lambda_function" "pagamento_function" {
  function_name = "lambda_pagamento_function"
  role          = aws_iam_role.lambda_execution_role.arn
  runtime       = "dotnet8"
  memory_size   = 512
  timeout       = 30
  handler       = "FIAP.TechChallenge.LambdaPagamento.API::FIAP.TechChallenge.LambdaPagamento.API.Function_Handler_Generated::Handler"
  # C�digo armazenado no S3
  s3_bucket = "code-lambdas-functions"
  s3_key    = "lambda_pagamento_function.zip"

  environment {
    variables = {
      url_sqs_atualiza_pagamento_pedido = data.aws_sqs_queue.atualiza_pagamento.id
    }
  }
}

# Cria��o da Tabela DynamoDB
resource "aws_dynamodb_table" "pagamento_table" {
  name         = "PagamentoTable"
  billing_mode = "PAY_PER_REQUEST"
  hash_key     = "id"

  attribute {
    name = "id"
    type = "S" # Tipo da chave: "S" para string, "N" para n�mero, "B" para bin�rio
  }

  # Opcional: Defini��o de uma chave de classifica��o (range key)
  #attribute {
  #  name = "id_guid"
  #  type = "S"
  #}

  tags = {
    Team = "Grupo12TechChallenge"
  }
}
