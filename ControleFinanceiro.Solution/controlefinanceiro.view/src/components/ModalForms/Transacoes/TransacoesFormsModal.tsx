import { useState } from "react";
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

  const tipoOptions = [
    { value: 1, label: "Despesa" },
    { value: 2, label: "Receita" },
  ];

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
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
          setFormData({ ...formData, valorDisplay: val });
          const numericValue = val.replace(/\./g, "").replace(",", ".");

          setFormData((prev) => ({
            ...prev,
            valor: parseFloat(numericValue) || 0,
          }));
        }}
      />
      <Select
        label="Tipo"
        required
        options={tipoOptions}
        value={formData.tipo}
        onChange={(val) => setFormData({ ...formData, tipo: parseInt(val) })}
      />
      <Select
        label="Categoria"
        required
        options={listCategorias.map((cat) => ({
          value: cat.codigo,
          label: cat.nome,
        }))}
        value={formData.categoriaCodigo}
        onChange={(val) =>
          setFormData({ ...formData, categoriaCodigo: parseInt(val) })
        }
      />
      <Select
        label="Pessoa"
        required
        options={listPessoas.map((p) => ({ value: p.codigo, label: p.nome }))}
        value={formData.pessoaCodigo}
        onChange={(val) =>
          setFormData({ ...formData, pessoaCodigo: parseInt(val) })
        }
      />
      <div className="form-actions">
        <Button
          descricao={isSubmitting ? "Processando..." : "Lançar Transação"}
          className="button-save"
          typeButton="submit"
        />
      </div>
    </form>
  );
}
