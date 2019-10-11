/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package pkg1920poker;

import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author maxime.rombaut
 */
public class HandTest {
    
    public HandTest() {
    }

    /**
     * Test of getValue method, of class Hand.
     */
    @Test
    public void testGetValue() {
    }
    @Test
    public void validHand(){
        Card[] validHand = new Card[]{
                new Card(Suit.CLUB, Rank.TWO),
                new Card(Suit.HEART, Rank.ACE),
                new Card(Suit.SPADE, Rank.KING),
                new Card(Suit.CLUB, Rank.THREE),
                new Card(Suit.DIAMOND, Rank.NINE)
            };
        Hand testHand = new Hand(validHand);
        assertEquals(5,testHand.getCards().length);
        
    }
    
}
