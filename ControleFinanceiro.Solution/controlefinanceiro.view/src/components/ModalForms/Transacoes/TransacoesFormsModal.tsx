import { useState, useMemo } from "react";
import { type TransacaoCriarDTO } from "../../../types/baseTypes/Transacao";
import { type Pessoa } from "../../../types/baseTypes/Pessoa";
import { type Categoria } from "../../../types/baseTypes/Categoria";
import { cadastrarNovaTransacao } from "../../../services/transacaoServices";
import Button from "../../Button/Button";
import Input from "../../Input/Input";
import Select from "../../Select/Select";
import "./style.css";

interface TransacaoFormProps {
  onSuccess: () => void;
  listPessoas: Pessoa[];
  listCategorias: Categoria[];
}

export default function TransacaoForm({
  onSuccess,
  listPessoas,
  listCategorias,
}: TransacaoFormProps) {
  const [formData, setFormData] = useState<TransacaoCriarDTO>({
    descricao: "",
    valor: 0,
    valorDisplay: "",
    tipo: 1,
    categoriaCodigo: 0,
    pessoaCodigo: 0,
  });
  const [isSubmitting, setIsSubmitting] = useState(false);

  const pessoaSelecionada = useMemo(
    () => listPessoas.find((p) => p.codigo === formData.pessoaCodigo),
    [listPessoas, formData.pessoaCodigo]
  );

  const isMenorDeIdade = pessoaSelecionada
    ? pessoaSelecionada.idade < 18
    : false;
  const isTipoInvalidoParaMenor = isMenorDeIdade && formData.tipo === 2;

  const categoriasFiltradas = useMemo(() => {
    return listCategorias.filter((cat) => {
      if (formData.tipo === 1)
        return cat.finalidade.codigo === 1 || cat.finalidade.codigo === 3;
      if (formData.tipo === 2)
        return cat.finalidade.codigo === 2 || cat.finalidade.codigo === 3;
      return true;
    });
  }, [listCategorias, formData.tipo]);

  const tipoOptions = [
    { value: 1, label: "Despesa" },
    { value: 2, label: "Receita" },
  ];

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (isTipoInvalidoParaMenor) return;

    setIsSubmitting(true);
    try {
      const resultado = await cadastrarNovaTransacao(formData);
      if (resultado) {
        onSuccess();
      }
    } catch (error: any) {
      alert("Erro ao cadastrar transação. Verifique os dados.");
    } finally {
      setIsSubmitting(false);
    }
  };

  return (
    <form onSubmit={handleSubmit} className="modal-form">
      <Input
        label="Descrição"
        placeholder="Ex: Pagamento Aluguel"
        required
        value={formData.descricao}
        onChange={(val) => setFormData({ ...formData, descricao: val })}
      />

      <Input
        label="Valor"
        isCurrency={true}
        value={formData.valorDisplay || ""}
        onChange={(val) => {
          const numericValue = val.replace(/\./g, "").replace(",", ".");
          setFormData((prev) => ({
            ...prev,
            valorDisplay: val,
            valor: parseFloat(numericValue) || 0,
          }));
        }}
      />

      <Select
        label="Pessoa"
        required
        options={listPessoas.map((p) => ({
          value: p.codigo,
          label: `${p.nome} (${p.idade} anos)`,
        }))}
        value={formData.pessoaCodigo}
        onChange={(val) => {
          const pCod = parseInt(val);
          const p = listPessoas.find((x) => x.codigo === pCod);
          setFormData({
            ...formData,
            pessoaCodigo: pCod,
            tipo: p && p.idade < 18 ? 1 : formData.tipo,
          });
        }}
      />

      <Select
        label="Tipo"
        required
        options={tipoOptions}
        value={formData.tipo}
        onChange={(val) => {
          setFormData({
            ...formData,
            tipo: parseInt(val),
            categoriaCodigo: 0,
          });
        }}
      />

      <Select
        label="Categoria"
        required
        options={categoriasFiltradas.map((cat) => ({
          value: cat.codigo,
          label: cat.nome,
        }))}
        value={formData.categoriaCodigo}
        onChange={(val) =>
          setFormData({ ...formData, categoriaCodigo: parseInt(val) })
        }
      />

      {isTipoInvalidoParaMenor && (
        <div style={{ color: "red", fontSize: "12px", marginBottom: "10px" }}>
          Menores de 18 anos não podem lançar receitas.
        </div>
      )}

      <div className="form-actions">
        <Button
          descricao={isSubmitting ? "Processando..." : "Lançar Transação"}
          className="button-save"
          typeButton="submit"
          disabled={
            isSubmitting ||
            isTipoInvalidoParaMenor ||
            formData.categoriaCodigo === 0 ||
            formData.pessoaCodigo === 0
          }
        />
      </div>
    </form>
  );
}
