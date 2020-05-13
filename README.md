# DocumentosBrasileiros
Validação e criação de números de documentos. Contempla Inscrição Estadual, CPF, CNPJ, PIS, CNH e Renavam

Desenvolvido em ASP.NET Core

### Instalação
```
Install-Package DocumentosBrasileiros
```

### Validando um documento:
```
  Documento doc = new Cnh("13975859080"); //Número gerado automaticamente
  
  bool valido = doc.DocumentoValido();
```

### Gerando um documento:
  
  ```
  Documento doc = new Cnh();
  
  doc.GerarFake();
  
  string numeroDoc = doc.Numero;

