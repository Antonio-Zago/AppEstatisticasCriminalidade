class Zona
{

  Zona(this._Id, this._LatitudeCentral, this._LongitudeCentral, this._Raio, this._IndiceFurto, this._Media, this._MediaMaxima);

  int _Id;

  double _LatitudeCentral;

  double _LongitudeCentral;

 double _Raio;

 double _IndiceFurto;

 double _Media;

 double _MediaMaxima;


  double get MediaMaxima => _MediaMaxima;

  set MediaMaxima(double value) {
    _MediaMaxima = value;
  }

  double get Media => _Media;

  set Media(double value) {
    _Media = value;
  }


  double get IndiceFurto => _IndiceFurto;

  set IndiceFurto(double value) {
    _IndiceFurto = value;
  }

  double get Raio => _Raio;

  set Raio(double value) {
    _Raio = value;
  }

  double get LongitudeCentral => _LongitudeCentral;

  set LongitudeCentral(double value) {
    _LongitudeCentral = value;
  }

  double get LatitudeCentral => _LatitudeCentral;

  set LatitudeCentral(double value) {
    _LatitudeCentral = value;
  }

  int get Id => _Id;

  set Id(int value) {
    _Id = value;
  }
}