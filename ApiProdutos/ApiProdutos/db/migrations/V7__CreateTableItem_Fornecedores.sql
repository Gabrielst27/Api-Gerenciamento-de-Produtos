CREATE SEQUENCE IF NOT EXISTS public.item_fornecedores_fornecprod_id_seq
    INCREMENT 1
    START 1;

CREATE TABLE IF NOT EXISTS public.item_fornecedores
(
    fornecprod_id bigint NOT NULL DEFAULT nextval('item_fornecedores_fornecprod_id_seq'::regclass),
    fornecprod_quant integer NOT NULL,
    fornecprod_fornec_id bigint NOT NULL,
    fornecprod_prod_id bigint NOT NULL,
    CONSTRAINT fornecprod_id_pkey PRIMARY KEY (fornecprod_id),
    CONSTRAINT item_fornecedores_fornecprod_prod_id_fkey FOREIGN KEY (fornecprod_prod_id)
        REFERENCES public.produtos (prod_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION,
    CONSTRAINT item_fornecedores_fornecprod_fornec_id_fkey FOREIGN KEY (fornecprod_fornec_id)
        REFERENCES public.fornecedores (fornec_id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
)