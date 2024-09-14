import 'package:appcrime/Controllers/AssaltoController.dart';
import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import '../Controllers/RouboController.dart';
import '../Models/Assalto.dart';
import 'Comuns/ItemMultiSelect.dart';
import 'Comuns/MultiSelect.dart';

class TelaReporteAssalto extends StatefulWidget {

  static const routeName = '/reportarAssalto';

  TelaReporteAssalto();

  @override
  State<TelaReporteAssalto> createState() => _TelaReporteAssaltoState();
}

const List<String> list = <String>['One', 'Two', 'Three', 'Four'];

class _TelaReporteAssaltoState extends State<TelaReporteAssalto> {

  late AssaltoController assaltoController;

  int dropdownValue = 1;


  void _mostrarOpcoes() async{
    final List<ItemMultiSelect> itens = assaltoController.tipoBens;

    final List<ItemMultiSelect> results = await showDialog(
        context: context,
        builder: (BuildContext context){
          return MultiSelect(itens: itens);
        }
    );

    if(results != null){
      assaltoController.itensSelecionados = results;
    }
  }

  @override
  void didChangeDependencies() {
    assaltoController = Provider.of<AssaltoController>(context);

    assaltoController.BuscarItens(context);
    assaltoController.BuscarTipoArmas(context);
    super.didChangeDependencies();
  }


  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Reportar assalto"),
      ),
      body: Container(
          padding: EdgeInsets.all(20),
          child: SingleChildScrollView(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Padding(
                  padding: EdgeInsets.fromLTRB(0, 0, 0, 15),
                  child: Observer(
                    builder: (_){
                      return TextField(
                        controller: assaltoController.dataController,
                        decoration: InputDecoration(
                          icon: Icon(Icons.calendar_today_rounded),
                          labelText: "Data da ocorrência",
                          errorText: assaltoController.validacaoData ? null : "Necessário selecionar uma data",
                        ),
                        onTap: () async{
                          DateTime? data = await showDatePicker(
                              context: context,
                              firstDate: DateTime(2000),
                              lastDate: DateTime(2101),
                              initialDate: DateTime.now()
                          );
                          if(data != null){
                            assaltoController.dataController.text = DateFormat("dd-MM-yyyy").format(data);
                            assaltoController.dataFormatada = DateFormat("yyyy-MM-dd hh:mm:ss").format(data);
                          }
                        },
                      );
                    },
                  ),
                ),
                Text("Descrição"),
                Padding(
                  padding: EdgeInsets.fromLTRB(0, 0,0, 15),
                  child: TextField(
                    keyboardType: TextInputType.text,
                    decoration: InputDecoration(
                        border: OutlineInputBorder()
                    ),
                    enabled: true,
                    style: TextStyle(
                      color: Colors.red,
                    ),
                    maxLines: 3,
                    controller: assaltoController.descricaoController,
                  ),
                ),
                Padding(
                  padding: EdgeInsets.fromLTRB(0, 0, 0, 15),
                  child: ElevatedButton(
                    onPressed: _mostrarOpcoes,
                    child: Text("Selecione os itens roubados"),
                  ),
                ),
                Observer(
                    builder: (_){
                      return Wrap(
                        children: assaltoController.itensSelecionados
                            .map((e) => Chip(
                          label: Text(e.nome),
                        )
                        ).toList(),
                      );
                    }
                ),
                Padding(
                  padding: EdgeInsets.fromLTRB(0, 0, 0, 15),
                  child: Row(
                    children: [
                      Observer(
                          builder: (_){
                            return Checkbox(
                              value: assaltoController.cadastrouBoletim,
                              onChanged: (bool? valor){
                                assaltoController.cadastrouBoletim = valor!;
                              },
                            );
                          }
                      ),
                      Text("Cadastrou boletim de ocorrência?"),
                    ],
                  ),
                ),
                Text("Quantidade de assaltantes"),
                Padding(
                  padding: EdgeInsets.fromLTRB(0, 0,0, 15),
                  child: SizedBox(
                    width: 100,
                    child: TextField(
                      keyboardType: TextInputType.number,
                      decoration: InputDecoration(
                        border: OutlineInputBorder(),
                      ),
                      enabled: true,
                      style: TextStyle(
                        color: Colors.red,
                      ),
                      controller: assaltoController.quantidadeAssaltantes,
                    ),
                  )
                ),
                Padding(
                  padding: EdgeInsets.fromLTRB(0, 0, 0, 15),
                  child: Row(
                    children: [
                      Observer(
                          builder: (_){
                            return Checkbox(
                              value: assaltoController.estavaArmado,
                              onChanged: (bool? valor){
                                assaltoController.estavaArmado = valor!;
                              },
                            );
                          }
                      ),
                      Text("Estava armado?"),
                    ],
                  ),
                ),
                Observer(
                    builder: (_){
                      return  Visibility(
                        visible: assaltoController.estavaArmado,
                        child:  Observer(
                          builder: (_){
                            return DropdownButton<int>(
                              value: assaltoController.tipoArma,
                              icon: const Icon(Icons.arrow_downward),
                              elevation: 16,
                              style: const TextStyle(color: Colors.deepPurple),
                              underline: Container(
                                height: 2,
                                color: Colors.deepPurpleAccent,
                              ),
                              onChanged: (int? value) {
                                // This is called when the user selects an item.
                                assaltoController.tipoArma = value!;
                              },
                              items: assaltoController.tipoArmas.map<DropdownMenuItem<int>>((ItemMultiSelect value) {
                                return DropdownMenuItem<int>(
                                  value: value.id,
                                  child: Text(value.nome),
                                );
                              }).toList(),
                            );
                          },
                        ),
                      );
                    }
                    ),
                TextButton(
                    onPressed: () async{
                      if(assaltoController.validarCampos()){
                        var assalto = Assalto(
                            assaltoController.itensSelecionados.map((a) => a.id).toList(),
                            assaltoController.descricaoController.text,
                            assaltoController.dataFormatada ,
                            assaltoController.cadastrouBoletim,
                            int.parse(assaltoController.quantidadeAssaltantes.text),
                            assaltoController.estavaArmado,
                            assaltoController.tipoArma
                        );
                        var response = await assaltoController.ReportarAssalto(assalto,context);
                        if(response == 200 && context.mounted){
                          ScaffoldMessenger.of(context).showSnackBar(
                            const SnackBar(content: Text('Cadastro feito com sucesso')),
                          );
                          assaltoController.limparCampos();
                        }
                      }
                      else{
                        if(!assaltoController.validacaoItens){
                          ScaffoldMessenger.of(context).showSnackBar(
                            const SnackBar(content: Text('Necessário selecionar ao menos um item roubado')),
                          );
                        }
                      }
                    },
                    child: Text("Reportar")
                )
              ],
            ),
          )

      ),
    );
  }
}
