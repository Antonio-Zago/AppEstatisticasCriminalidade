import 'package:flutter/material.dart';

import 'ItemMultiSelect.dart';

class MultiSelect extends StatefulWidget {

  final List<ItemMultiSelect> itens;
  const MultiSelect({Key? key, required this.itens}) : super(key: key);

  @override
  State<MultiSelect> createState() => _MultiSelectState();
}

class _MultiSelectState extends State<MultiSelect> {

  final List<ItemMultiSelect> _itensSelecionados = [];

  void itemChange(ItemMultiSelect itemValue, bool isSelected){
    setState(() {
      if(isSelected){
        _itensSelecionados.add(itemValue);
      }
      else{
        _itensSelecionados.remove(itemValue);
      }
    });
  }

  void _cancel(){
    Navigator.pop(context);
  }

  void _submit(){
    Navigator.pop(context,_itensSelecionados);
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: const Text("Selecione"),
      content: SingleChildScrollView(
        child: ListBody(
            children: widget.itens.map((item) => CheckboxListTile(
              value: _itensSelecionados.contains(item),
              title: Text(item.nome),
              controlAffinity: ListTileControlAffinity.leading,
              onChanged: (estaSelecionado) => itemChange(item,estaSelecionado!),
            )
            ).toList()
        ),
      ),
      actions: [
        TextButton(
            onPressed: _cancel,
            child: Text("Cancelar")
        ),
        TextButton(
            onPressed: _submit,
            child: Text("Ok")
        )
      ],
    );
  }


}