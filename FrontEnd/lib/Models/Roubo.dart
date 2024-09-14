class Roubo{

  Roubo(this._tipoBens, this._descricao, this._dataHora,
      this._cadastrouBoletimOcorrencia);

  List<int> _tipoBens;

  String _descricao;

  String _dataHora;

  bool _cadastrouBoletimOcorrencia;

  bool get cadastrouBoletimOcorrencia => _cadastrouBoletimOcorrencia;

  set cadastrouBoletimOcorrencia(bool value) {
    _cadastrouBoletimOcorrencia = value;
  }

  String get dataHora => _dataHora;

  set dataHora(String value) {
    _dataHora = value;
  }

  String get descricao => _descricao;

  set descricao(String value) {
    _descricao = value;
  }

  List<int> get tipoBens => _tipoBens;

  set tipoBens(List<int> value) {
    _tipoBens = value;
  }
}