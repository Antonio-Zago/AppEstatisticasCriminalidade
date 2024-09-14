class ItemMultiSelect{

  ItemMultiSelect(this._id, this._nome);

  int _id;

  String _nome;

  int get id => _id;

  set id(int value) {
    _id = value;
  }

  String get nome => _nome;

  set nome(String value) {
    _nome = value;
  }
}