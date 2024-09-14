class Assalto{

  Assalto(
      this._tipoBens,
      this._descricao,
      this._dataHora,
      this._cadastrouBoletimOcorrencia,
      this._quantidadeAgressores,
      this._possuiArma,
      this._tipoArma);

  List<int> _tipoBens;

  String _descricao;

  String _dataHora;

  bool _cadastrouBoletimOcorrencia;

  int _quantidadeAgressores;


  bool _possuiArma;

  int _tipoArma;


  int get quantidadeAgressores => _quantidadeAgressores;

  set quantidadeAgressores(int value) {
    _quantidadeAgressores = value;
  }

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

  bool get possuiArma => _possuiArma;

  set possuiArma(bool value) {
    _possuiArma = value;
  }

  int get tipoArma => _tipoArma;

  set tipoArma(int value) {
    _tipoArma = value;
  }
}