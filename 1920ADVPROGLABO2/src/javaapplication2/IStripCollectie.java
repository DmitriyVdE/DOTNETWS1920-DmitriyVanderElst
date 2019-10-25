/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package javaapplication2;

import javaapplication2.Strip;

/**
 *
 * @author Peter
 */
public interface IStripCollectie {

    public Strip[] getStrips(String reeks);    

    public void verwijder(Strip strip);

    public void voegToe(Strip strip);
    
}
