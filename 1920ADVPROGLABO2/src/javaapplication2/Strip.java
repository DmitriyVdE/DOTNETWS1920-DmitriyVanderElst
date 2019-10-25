/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication2;

import java.util.Objects;

/**
 *
 * @author Brecht Bekaert
 */
public class Strip implements Comparable<Strip>{
    private String reeks;
    private String titel;
    private int reeksnummer;
    private String tekenaar;
    private String schrijver;
    private String uitgeverij;

    public Strip(String reeks, String titel, String tekenaar, String schrijver, int reeksnummer, String uitgeverij) {
        this.reeks = reeks;
        this.titel = titel;
        this.reeksnummer = reeksnummer;
        this.tekenaar = tekenaar;
        this.schrijver = schrijver;
        this.uitgeverij = uitgeverij;
    }

    public String getReeks() {
        return reeks;
    }

    public String getTitel() {
        return titel;
    }

    public int getReeksnummer() {
        return reeksnummer;
    }

    public String getTekenaar() {
        return tekenaar;
    }

    public String getSchrijver() {
        return schrijver;
    }

    public String getUitgeverij() {
        return uitgeverij;
    }

    @Override
    public int compareTo(Strip o) {
        if (this.reeks.equals(o.reeks)){
            return Integer.compare(this.reeksnummer, o.reeksnummer);
        }
        else {
            return this.reeks.compareTo(o.reeks);
        }
    }

    @Override
    public int hashCode() {
        int hash = 3;
        return hash;
    }

    @Override
    public boolean equals(Object obj) {
        if (this == obj) {
            return true;
        }
        if (obj == null) {
            return false;
        }
        if (getClass() != obj.getClass()) {
            return false;
        }
        final Strip other = (Strip) obj;
        if (this.reeksnummer != other.reeksnummer) {
            return false;
        }
        if (!Objects.equals(this.reeks, other.reeks)) {
            return false;
        }
        if (!Objects.equals(this.titel, other.titel)) {
            return false;
        }
        if (!Objects.equals(this.tekenaar, other.tekenaar)) {
            return false;
        }
        if (!Objects.equals(this.schrijver, other.schrijver)) {
            return false;
        }
        if (!Objects.equals(this.uitgeverij, other.uitgeverij)) {
            return false;
        }
        return true;
    }
    
    
}
