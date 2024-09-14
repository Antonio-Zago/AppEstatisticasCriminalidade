// GENERATED CODE - DO NOT MODIFY BY HAND

part of 'ZonaController.dart';

// **************************************************************************
// StoreGenerator
// **************************************************************************

// ignore_for_file: non_constant_identifier_names, unnecessary_brace_in_string_interps, unnecessary_lambdas, prefer_expression_function_bodies, lines_longer_than_80_chars, avoid_as, avoid_annotating_with_dynamic, no_leading_underscores_for_local_identifiers

mixin _$ZonaController on ZonaControllerBase, Store {
  late final _$zonasAtom =
      Atom(name: 'ZonaControllerBase.zonas', context: context);

  @override
  List<Zona> get zonas {
    _$zonasAtom.reportRead();
    return super.zonas;
  }

  @override
  set zonas(List<Zona> value) {
    _$zonasAtom.reportWrite(value, super.zonas, () {
      super.zonas = value;
    });
  }

  late final _$GetAllZonasAsyncAction =
      AsyncAction('ZonaControllerBase.GetAllZonas', context: context);

  @override
  Future<List<Zona>> GetAllZonas() {
    return _$GetAllZonasAsyncAction.run(() => super.GetAllZonas());
  }

  @override
  String toString() {
    return '''
zonas: ${zonas}
    ''';
  }
}
