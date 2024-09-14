class Usuario{

  Usuario(this._nome, this._email, this._senha, this._cpf);

  String _nome;

  String _email;

  String _senha;

  String _cpf;

  String get nome => _nome;

  set nome(String value) {
    _nome = value;
  }

  String get email => _email;

  set email(String value) {
    _email = value;
  }

  String get senha => _senha;

  set senha(String value) {
    _senha = value;
  }

  String get cpf => _cpf;

  set cpf(String value) {
    _cpf = value;
  }
}