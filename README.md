# DocumentosBrasileiros
Validação e criação de números de documentos. Contempla Inscrição Estadual, CPF, CNPJ, PIS, CNH e Renavam

Desenvolvido em ASP.NET Core

### Instalação
```
Install-Package DocumentosBrasileiros
```

### Validando um documento:
```
  Documento doc = new Documento("13975859080", TipoDocumento.CNH); //Número gerado automaticamente
  
  bool valido = doc.DocumentoValido();
```

### Gerando um documento:
  
  ```
  Documento doc = new Documento(TipoDocumento.CNH);
  
  doc.GerarDocumento();
  
  string numeroDoc = doc.Numero;

