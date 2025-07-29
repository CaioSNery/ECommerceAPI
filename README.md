# 🛒 ECommerceAPI

API REST construída com **ASP.NET Core 8** para gerenciar um sistema de e-commerce com foco em boas práticas de arquitetura, separação de responsabilidades e escalabilidade.

---

## ✅ Funcionalidades Implementadas

- Cadastro e gerenciamento de **Clientes**, **Produtos**, **Categorias**, **Pedidos** e **Carrinhos**
- Estrutura organizada em **camadas (Controllers, Services, Repositories, DTOs)**
- Mapeamento com **Entity Framework Core + Fluent API**
- Mapeamento de objetos com **AutoMapper**
- Autenticação via **JWT Token**
- Envio de notificações via **Twilio SMS**
- Envio de e-mails via **SMTP**
- Banco de dados com **SQL Server**

---

## 🔐 Autenticação com JWT

- Login via `POST /api/auth/login`
- Registro de novos usuários `POST /api/auth/register`
- Proteção de rotas com `[Authorize]`
- Tokens com tempo de expiração e uso de **Refresh Token**
- Suporte a diferentes perfis de usuário (ex: Admin, Cliente)

### 🔒 Exemplo de uso no header:
```
Authorization: Bearer {token}
```

---

## 🧱 Estrutura do Projeto

```
ECommerceAPI/
├── Controllers/          # Endpoints da aplicação
├── Services/             # Regras de negócio
├── Repositories/         # Acesso ao banco de dados
├── Dtos/                 # Objetos de transferência de dados
├── Models/               # Entidades do domínio
├── Data/                 # DbContext e configurações EF Core
├── Mappings/             # Perfis do AutoMapper
├── Settings/             # Configurações externas (Twilio, SMTP)
├── Program.cs            # Configurações principais da aplicação
└── appsettings.json      # Strings de conexão e chaves de API
```

---

## ⚙️ Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- SQL Server
- AutoMapper
- JWT Authentication
- Twilio (SMS)
- SMTP (Email)
- Swagger

---

## 🌐 Swagger

Acesse a documentação interativa da API com suporte ao JWT via:
```
/swagger
```

---

## 👨‍💻 Desenvolvedor

**Caio de Souza Nery**  
Desenvolvedor backend com foco em APIs RESTful robustas, seguras e escaláveis. Apaixonado por boas práticas, automação e aprendizado contínuo.

---

## 📌 Observações

> Projeto em desenvolvimento contínuo. Recursos como pagamento online e histórico de pedidos por cliente serão adicionados futuramente.
