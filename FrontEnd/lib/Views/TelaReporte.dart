import 'package:appcrime/Controllers/RouboController.dart';
import 'package:appcrime/Views/Comuns/ItemMultiSelect.dart';
import 'package:appcrime/Models/Roubo.dart';
import 'package:flutter/material.dart';
import 'package:flutter_mobx/flutter_mobx.dart';
import 'package:intl/intl.dart';
import 'package:provider/provider.dart';

import 'Comuns/MultiSelect.dart';

class TelaReporte extends StatefulWidget {

  static const routeName = '/reportar';

  TelaReporte();

  @override
  State<TelaReporte> createState() => _TelaReporteState();
}

class _TelaReporteState extends State<TelaReporte> {

  late RouboController rouboController;

  void _mostrarOpcoes() async{
    final List<ItemMultiSelect> itens = rouboController.tipoBens;

    final List<ItemMultiSelect> results = await showDialog(
        context: context,
        builder: (BuildContext context){
          return MultiSelect(itens: itens);
        }
    );

    if(results != null){
        rouboController.itensSelecionados = results;
    }
  }

  @override
  void didChangeDependencies() {
    rouboController = Provider.of<RouboController>(context);

    rouboController.BuscarItens(context);
    super.didChangeDependencies();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text("Reportar roubo"),
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
                      controller: rouboController.dataController,
                      decoration: InputDecoration(
                        icon: Icon(Icons.calendar_today_rounded),
                        labelText: "Data da ocorrência",
                        errorText: rouboController.validacaoData ? null : "Necessário selecionar uma data",
                      ),
                      onTap: () async{
                        DateTime? data = await showDatePicker(
                            context: context,
                            firstDate: DateTime(2000),
                            lastDate: DateTime(2101),
                            initialDate: DateTime.now()
                        );
                        if(data != null){
                          rouboController.dataController.text = DateFormat("dd-MM-yyyy").format(data);
                          rouboController.dataFormatada = DateFormat("yyyy-MM-dd hh:mm:ss").format(data);
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
                  controller: rouboController.descricaoController,
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
                      children: rouboController.itensSelecionados
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
                            value: rouboController.cadastrouBoletim,
                            onChanged: (bool? valor){
                                rouboController.cadastrouBoletim = valor!;
                            },
                          );
                        }
                    ),
                    Text("Cadastrou boletim de ocorrência?"),
                  ],
                ),
              ),
              TextButton(
                  onPressed: () async{
                    if(rouboController.validarCampos()){
                      var roubo = Roubo(rouboController.itensSelecionados.map((a) => a.id).toList(),rouboController.descricaoController.text, rouboController.dataFormatada ,rouboController.cadastrouBoletim);
                      var response = await rouboController.ReportarRoubo(roubo,context);
                      if(response == 200 && context.mounted){
                        ScaffoldMessenger.of(context).showSnackBar(
                          const SnackBar(content: Text('Cadastro feito com sucesso')),
                        );
                        rouboController.limparCampos();
                      }
                    }
                    else{
                      if(!rouboController.validacaoItens){
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
