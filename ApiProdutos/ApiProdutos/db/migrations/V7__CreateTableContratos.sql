CREATE SEQUENCE IF NOT EXISTS public.contratos_contr_id_seq
    INCREMENT 1
    START 1;

CREATE TABLE IF NOT EXISTS public.contratos
(
    contr_id bigint NOT NULL DEFAULT nextval('contratos_contr_id_seq'::regclass),
    contr_codinterno character varying(30) COLLATE pg_catalog."default" NOT NULL,
    contr_valor_inicial decimal(15,2) NOT NULL,
    contr_valor_mensal decimal(15,2) NOT NULL,
    contr_reajuste decimal(5,2) NOT NULL,
    contr_tipo character varying(20) COLLATE pg_catalog."default" NOT NULL,
    contr_representante character varying(60) COLLATE pg_catalog."default" NOT NULL,
    contr_data_inicial timestamp without time zone DEFAULT CURRENT_TIMESTAMP,
    contr_dia_cobranca timestamp without time zone NOT NULL,
    contr_data_expira timestamp without time zone NOT NULL,
    contr_status integer NOT NULL,
    contr_emp_id bigint NOT NULL,
    CONSTRAINT contratos_pkey PRIMARY KEY (contr_id),
    CONSTRAINT contratos_contr_emp_id_fkey FOREIGN KEY (contr_emp_id)
    REFERENCES public.fornecedores (fornec_id)
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)