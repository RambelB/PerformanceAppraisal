--
-- PostgreSQL database dump
--

-- Dumped from database version 16.3
-- Dumped by pg_dump version 16.3

-- Started on 2024-08-01 11:30:24

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 222 (class 1259 OID 16489)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16438)
-- Name: indikatorArea; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."indikatorArea" (
    id character varying NOT NULL,
    aspek character varying NOT NULL,
    keterangan character varying NOT NULL,
    target integer NOT NULL,
    aktual integer NOT NULL,
    "tingkatUnjukKerja" integer NOT NULL,
    "nilaiUnjukKerja" integer NOT NULL,
    "rekapId" character varying NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    created_by integer,
    updated_at timestamp without time zone,
    updated_by integer
);


ALTER TABLE public."indikatorArea" OWNER TO postgres;

--
-- TOC entry 218 (class 1259 OID 16424)
-- Name: indikatorUtamaKerja; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."indikatorUtamaKerja" (
    id character varying NOT NULL,
    "strategicObjective" character varying NOT NULL,
    kpi character varying NOT NULL,
    "UoM" character varying NOT NULL,
    polarisasi character varying NOT NULL,
    target integer NOT NULL,
    aktual integer NOT NULL,
    "tingkatUnjukKerja" integer NOT NULL,
    "nilaiUnjukKerja" integer NOT NULL,
    "rekapId" character varying NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    created_by integer,
    updated_at timestamp without time zone,
    updated_by integer
);


ALTER TABLE public."indikatorUtamaKerja" OWNER TO postgres;

--
-- TOC entry 4898 (class 0 OID 0)
-- Dependencies: 218
-- Name: COLUMN "indikatorUtamaKerja".kpi; Type: COMMENT; Schema: public; Owner: postgres
--

COMMENT ON COLUMN public."indikatorUtamaKerja".kpi IS 'Content of the post';


--
-- TOC entry 219 (class 1259 OID 16431)
-- Name: kompetensiDasar; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."kompetensiDasar" (
    id character varying NOT NULL,
    "customerFocus" character varying NOT NULL,
    integritas character varying NOT NULL,
    "kerjasamaTim" character varying NOT NULL,
    "continuousImprovement" character varying NOT NULL,
    "workExcellence" character varying NOT NULL,
    "rekapId" character varying NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    created_by integer,
    updated_at timestamp without time zone,
    updated_by integer
);


ALTER TABLE public."kompetensiDasar" OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16403)
-- Name: kpi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.kpi (
    id character varying NOT NULL,
    nama character varying NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    created_by integer,
    updated_at timestamp without time zone,
    updated_by integer
);


ALTER TABLE public.kpi OWNER TO postgres;

--
-- TOC entry 221 (class 1259 OID 16445)
-- Name: perubahanNilai; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."perubahanNilai" (
    id character varying NOT NULL,
    "lostTimeInjury" integer NOT NULL,
    project integer DEFAULT 0 NOT NULL,
    sga integer DEFAULT 0 NOT NULL,
    "auditorOrTrainer" integer DEFAULT 0 NOT NULL,
    "rekapId" character varying,
    created_at timestamp without time zone DEFAULT now(),
    created_by integer,
    updated_at timestamp without time zone,
    updated_by integer,
    "suratPeringatan" integer DEFAULT 0 NOT NULL,
    "fireIncident" integer DEFAULT 0 NOT NULL
);


ALTER TABLE public."perubahanNilai" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16417)
-- Name: rekapitulasi; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.rekapitulasi (
    id character varying NOT NULL,
    periode character varying NOT NULL,
    "NIK" integer NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    created_by integer,
    updated_at timestamp without time zone,
    updated_by integer
);


ALTER TABLE public.rekapitulasi OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16410)
-- Name: users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.users (
    "NIK" integer NOT NULL,
    nama character varying NOT NULL,
    "divisiOrDepartemen" character varying NOT NULL,
    jabatan character varying NOT NULL,
    created_at timestamp without time zone DEFAULT now() NOT NULL,
    created_by integer,
    updated_at timestamp without time zone,
    updated_by integer,
    password character varying DEFAULT ''::character varying NOT NULL
);


ALTER TABLE public.users OWNER TO postgres;

--
-- TOC entry 4743 (class 2606 OID 16493)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 4739 (class 2606 OID 16444)
-- Name: indikatorArea indikatorArea_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."indikatorArea"
    ADD CONSTRAINT "indikatorArea_pkey" PRIMARY KEY (id);


--
-- TOC entry 4735 (class 2606 OID 16430)
-- Name: indikatorUtamaKerja indikatorUtamaKerja_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."indikatorUtamaKerja"
    ADD CONSTRAINT "indikatorUtamaKerja_pkey" PRIMARY KEY (id);


--
-- TOC entry 4737 (class 2606 OID 16437)
-- Name: kompetensiDasar kompetensiDasar_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."kompetensiDasar"
    ADD CONSTRAINT "kompetensiDasar_pkey" PRIMARY KEY (id);


--
-- TOC entry 4729 (class 2606 OID 16409)
-- Name: kpi kpi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.kpi
    ADD CONSTRAINT kpi_pkey PRIMARY KEY (id);


--
-- TOC entry 4741 (class 2606 OID 16451)
-- Name: perubahanNilai perubahanNilai_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."perubahanNilai"
    ADD CONSTRAINT "perubahanNilai_pkey" PRIMARY KEY (id);


--
-- TOC entry 4733 (class 2606 OID 16423)
-- Name: rekapitulasi rekapitulasi_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rekapitulasi
    ADD CONSTRAINT rekapitulasi_pkey PRIMARY KEY (id);


--
-- TOC entry 4731 (class 2606 OID 16416)
-- Name: users users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY ("NIK");


--
-- TOC entry 4748 (class 2606 OID 16467)
-- Name: indikatorArea indikatorArea_rekapId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."indikatorArea"
    ADD CONSTRAINT "indikatorArea_rekapId_fkey" FOREIGN KEY ("rekapId") REFERENCES public.rekapitulasi(id);


--
-- TOC entry 4745 (class 2606 OID 16452)
-- Name: indikatorUtamaKerja indikatorUtamaKerja_kpi_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."indikatorUtamaKerja"
    ADD CONSTRAINT "indikatorUtamaKerja_kpi_fkey" FOREIGN KEY (kpi) REFERENCES public.kpi(id);


--
-- TOC entry 4746 (class 2606 OID 16457)
-- Name: indikatorUtamaKerja indikatorUtamaKerja_rekapId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."indikatorUtamaKerja"
    ADD CONSTRAINT "indikatorUtamaKerja_rekapId_fkey" FOREIGN KEY ("rekapId") REFERENCES public.rekapitulasi(id);


--
-- TOC entry 4747 (class 2606 OID 16462)
-- Name: kompetensiDasar kompetensiDasar_rekapId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."kompetensiDasar"
    ADD CONSTRAINT "kompetensiDasar_rekapId_fkey" FOREIGN KEY ("rekapId") REFERENCES public.rekapitulasi(id);


--
-- TOC entry 4749 (class 2606 OID 16477)
-- Name: perubahanNilai perubahanNilai_rekapId_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."perubahanNilai"
    ADD CONSTRAINT "perubahanNilai_rekapId_fkey" FOREIGN KEY ("rekapId") REFERENCES public.rekapitulasi(id);


--
-- TOC entry 4744 (class 2606 OID 16472)
-- Name: rekapitulasi rekapitulasi_NIK_fkey; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.rekapitulasi
    ADD CONSTRAINT "rekapitulasi_NIK_fkey" FOREIGN KEY ("NIK") REFERENCES public.users("NIK");


-- Completed on 2024-08-01 11:30:25

--
-- PostgreSQL database dump complete
--

