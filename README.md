# DocumentosBrasileiros
Validação e criação de números de documentos. Contempla Inscrição Estadual, CPF, CNPJ, PIS, CNH e Renavam

Desenvolvido em ASP.NET Core

### Instalação
```
Install-Package DocumentosBrasileiros
```

### Validando um documento:
```
  var cnh = new Cnh("13975859080"); //Número gerado automaticamente
  
  bool valido = cnh.DocumentoValido();
```

### Gerando um documento:
  
  ```
  var cnh = new Cnh();
  
  cnh.GerarFake();
  
  string numeroDoc = cnh.Numero;

